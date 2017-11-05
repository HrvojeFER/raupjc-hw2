using System;
using System.Collections.Generic;
using System.Linq;
using GenericListEnumerator;

namespace Z2
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            _inMemoryTodoDatabase = initialDbState ?? new GenericList<TodoItem>();
        }

        public TodoItem Get(Guid todoId)
        {
            try
            {
                return _inMemoryTodoDatabase.Last(x => x.Id == todoId);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public TodoItem Add(TodoItem todoItem)
        {
            var checkItem = Get(todoItem.Id);
            if (checkItem != null)
            {
                throw new DuplicateTodoItemException(ref checkItem);
            }

            _inMemoryTodoDatabase.Add(todoItem);

            return Get(todoItem.Id);
        }

        public bool Remove(Guid todoId)
        {
            return _inMemoryTodoDatabase.Remove(Get(todoId));
        }

        public TodoItem Update(TodoItem todoItem)
        {
            try
            {
                return Add(todoItem);
            }
            catch (DuplicateTodoItemException ex)
            {
                ex.Item.DateCompleted = todoItem.DateCompleted;
                ex.Item.DateCreated = todoItem.DateCreated;
                ex.Item.Text = todoItem.Text;

                return ex.Item;
            }

            /*
             * Drugo rješenje (ako objekt postoji, miče ga)
            var checkItem = Get(todoItem.Id);

            if (checkItem != null)
            {
                Remove(checkItem.Id);
            }
            
            return Add(todoItem);
            */
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            var item = Get(todoId);
            if (item == null)
            {
                return false;
            }

            item.MarkAsCompleted();
            return true;
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderBy(x => x.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(x => !x.IsCompleted).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(x => x.IsCompleted).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }
    }

    public class DuplicateTodoItemException : Exception
    {
        public TodoItem Item { get; private set; }

        public DuplicateTodoItemException(ref TodoItem item) : base($"duplicate id : {item.Id}")
        {
            Item = item;
        }
    }
}
