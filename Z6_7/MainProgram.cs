using System;
using System.Threading.Tasks;

namespace Z6_7
{
    public class MainProgram
    {
        private static async Task<int> Fact(int n)
        {
            return n == 2 ? 2 : n * await Fact(n - 1);
        }

        private static async Task<int> DigitSum(int n)
        {
            return n == 0 ? 0 : n % 10 + await DigitSum(n / 10);
        }

        private static async Task<int> FactorialDigitSumAsync(int n)
        {
            return await DigitSum(await Fact(n));
        }

        private static async Task LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static async Task<int> GetTheMagicNumber()
        {
            return await AiKnowAGuyWhoKnowsAGuy();
        }
        private static async Task<int> AiKnowAGuyWhoKnowsAGuy()
        {
            return await AiKnowWhoKnowsThis(10) + await AiKnowWhoKnowsThis(5);
        }
        private static async Task<int> AiKnowWhoKnowsThis(int n)
        {
            return await FactorialDigitSumAsync(n);
        }

        public static void Main(string[] args)
        {
            Task.Run(LetsSayUserClickedAButtonOnGuiMethod);
            Console.Read();
        }
    }
}