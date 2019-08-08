using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Given weights and values of N items, we need to put these items in a knapsack of capacity W to get the maximum total value in the knapsack.
                Note: Unlike 0/1 knapsack, you are allowed to bread the item.

                Input:
                First line consists of an integer T denoting the number of test cases. First line consists of two integers N and W, denoting number of items and weight respectively. Second line of every test case consists of 2*N spaced integers denoting Values and weight respectively. (Value1 Weight1 Value2 Weight2.... ValueN WeightN)

                Output:
                Print the maximum value possible to put items in a knapsack, upto 2 decimal place.

                Constraints:
                1 <= T <= 100
                1 <= N <= 100
                1 <= W <= 100

                Example:
                Input:
                2
                3 50
                60 10 100 20 120 30
                2 50
                60 10 100 20

                Output:
                240.00
                160.00 
            */

            var testCases = double.Parse(ReadLine());

            for (int i = 0; i < testCases; i++)
            {
                var firstInput = ReadLine();
                var numberOfItems = int.Parse(firstInput.Split(' ')[0]);
                WriteLine(numberOfItems);
                var weight = int.Parse(firstInput.Split(' ')[1]);
                WriteLine(weight);

                var valuesAndWeights = ReadLine().Split(' ');

                var items = CreateItems(valuesAndWeights, numberOfItems);
                var optimalSolution = FractionalKnapsackBestValue(items, weight);
                WriteLine(optimalSolution);
            }
        }

        static decimal FractionalKnapsackBestValue(List<Item> items, decimal capacity)
        {
            var knapsack = new List<Item>();

            var orderedItems = items.OrderByDescending(currentItem => currentItem.CostBenefit);

            foreach (var item in orderedItems)
            {
                if (capacity == 0)
                    break;

                if (item.Weight > capacity)
                {
                    item.Value = capacity * item.Value / item.Weight;
                    item.Weight = capacity;
                }
                    
                knapsack.Add(item);
                capacity -= item.Weight;
            }

            return knapsack.Sum(x => x.Value);
        }

        static List<Item> CreateItems(string[] valuesAndWeights, int numberOfItems)
        {
            var items = new List<Item>();

            for (int j = 0; j < numberOfItems * 2; j = j + 2)
            {
                var item = new Item
                {
                    Value = decimal.Parse(valuesAndWeights[j]),
                    Weight = decimal.Parse(valuesAndWeights[j + 1])
                };
                items.Add(item);
            }

            return items;
        }
    }
}