using System;
using System.Collections.Generic;
using System.Text;

namespace knapsack
{
    public class Item
    {
        public decimal Value { get; set; }
        public decimal Weight { get; set; }

        public decimal CostBenefit { get => Value/Weight; }
    }
}
