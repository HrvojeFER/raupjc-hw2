using System;
using System.Collections.Generic;

namespace Z2
{
    public interface ITodoRepository
    {

        TodoItem Get(Guid todoId);

        TodoItem Add(TodoItem todoItem);

        bool Remove(Guid todoId);

        TodoItem Update(TodoItem todoItem);

        bool MarkAsCompleted(Guid todoId);

        List<TodoItem> GetAll ();

        List<TodoItem> GetActive();

        List<TodoItem> GetCompleted();

        List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction);
    }
}
