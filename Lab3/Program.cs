using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculate = new Calculator();

            //Инструкция
            Console.WriteLine("Инструкция: \n" +
                "Введите выражение и нажмите 'Enter'\n" +
                "При вводе Вы можете использовать пробелы, знаки (+, -, *);");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("!!!  При вводе НЕ целых чисел - используйте ','  !!!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Доступен посимвольный ввод (пример: 6 'Enter' операнд 'Enter' 7 'Enter')\n" +
                  "Для получения результатов нажмите 'Enter'\n\n" +
                  "----------Калькулятор----------");

            //Переменная 'i' используется присвоения результата конкретному выражению;
            //Также используется для последовательного вывода на экран результатов
              int i = 0; 
              while(true)
              {
                  calculate.EnterExpressionAndParsing(); //Вызов метода ввода выражений и парсинга

                  if(String.IsNullOrEmpty(calculate.Expression)) //Проверка пустая ли строка. Если да - прекращение работы цикла
                  {
                      break;
                  }
                  calculate.CalculateExpression(i); //Расчёт выражений
                  i++;
              }
              calculate.GetInfo(i); //Вывод результата на экран
        }
    }
}
