using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Calculator
    {
        Operations operation = new Operations();
        private char _symbol; //Переменная запоминает символ (+,- или *) для определения операции, которую нужно выполнить(сумма, розница или умножение)
        private string _expression; //Переменная принимает данные, введеные с клавиатуры
        private string[] _arguments; //Массив получает 2 аргумента со всей строки (тип: String)
        private decimal[] _values = new decimal[2]; //Массив получает 2 аргумента (после парсинга; тип: Decimal)
        private List<decimal> _result = new List<decimal>(); // Список, который имеет в себе результаты вычислений
        private char[] _delimeterChars = {' ', '+', '-', '*', '='}; // Массив символов, по которым строка разбивается на массив аргументов;
        public string Expression 
        {
            get
            {
                return _expression;
            }
        }

        public void EnterExpressionAndParsing()
        {
            Console.WriteLine("Введите выражение: ");
            _expression = Console.ReadLine();
            if(String.IsNullOrEmpty(_expression)) //Выполняется проверка - пустая ли строка, если да - выход из метода
            {
                return;
            }
            _arguments = _expression.Split(_delimeterChars, StringSplitOptions.RemoveEmptyEntries); //Получаем массив из двух элементов(тип String), убираем лишние символы(пробелы)
            
            // Получаем символ для дальнейшей операции (+,- или *)
            char[] symbol = _expression.ToCharArray();
            int a = 0;
            foreach (char i in symbol)
            {
                if ((i == '+') || (i == '-') || (i == '*'))
                {
                    _symbol = i;
                    a++;
                }
            }
            _values[0] = Convert.ToDecimal(_arguments[0]); //Парсинг первого аргумента

            //Если введено всё выражение сразу - парсинг второго аргумента
            if (_arguments.Length > 1) 
            {
                _values[1] = Convert.ToDecimal(_arguments[1]); 
            }
            
            //Дальнейший код реализует ввод аргументов по одному (аргумент1 'Enter' операнд 'Enter' аргумент2 'Enter')
            if (a == 0)
            {
                _expression = Console.ReadLine();
                symbol = _expression.ToCharArray();
                foreach (char i in symbol)
                {
                    if ((i == '+') || (i == '-') || (i == '*'))
                    {
                        _symbol = i;
                    }
                }
                if ((symbol[0] != '+') && (symbol[0] != '-') && (symbol[0] != '*'))
                {
                    Console.WriteLine("Вы не ввели операнд!");
                }
                _expression = Console.ReadLine();
                _arguments = _expression.Split(_delimeterChars, StringSplitOptions.RemoveEmptyEntries);
                _values[1] = Convert.ToDecimal(_arguments[0]); 
            }
        }

        //Вычисление результата, вызов класса Operations где прописаны формулы калькулятора
        public void CalculateExpression(int i) 
        {
            _result.Add(1); //Добавляем в список _result 1 элемент
            if (_symbol == '+')
            {
                _result[i] = operation.Sum(_values);
            }
            if (_symbol == '-')
            {
                _result[i] = operation.Subtraction(_values);
            }
            if (_symbol == '*')
            {
                _result[i] = operation.Multiplication(_values);
            }

        }
        public void GetInfo(int i) //вывод на экран результатов
        {
            Console.WriteLine("Результат: ");
            for(int a = 0; a < i; a++)
            {
                Console.WriteLine(_result[a]);
            }
        }
    }
}
