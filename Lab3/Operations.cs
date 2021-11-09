using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{

    // Класс имеет в себе формулы для вычисления выражения
    class Operations
    {
        private decimal _sum;
        private decimal _difference;
        private decimal _product;
        public decimal Sum(decimal[] values)
        {
            _sum = values[0] + values[1];
            return _sum;
        }
        public decimal Subtraction(decimal[] values)
        {
            _difference = values[0] - values[1];
            return _difference;
        }
        public decimal Multiplication(decimal[] values)
        {
            _product = values[0] * values[1];
            return _product;
        }
    }
}
