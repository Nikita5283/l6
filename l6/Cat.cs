using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace l6
{
    /// <summary>
    /// Класс, представляющий сущность Кот.
    /// Реализует IMeowable для возможности участия в общих коллекциях мяукающих объектов.
    /// </summary>
    internal class Cat : IMeowable
    {
        private string _name;

        /// <summary>
        /// Свойство для получения и установки имени кота.
        /// </summary>
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    // Проверка входных данных
                    Console.WriteLine("Внимание: Имя не может быть пустым. Установлено имя 'Барсик'.");
                    _name = "Барсик";
                }
                else
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Создает нового кота с указанным именем.
        /// </summary>
        /// <param name="name">Имя кота.</param>
        public Cat(string name)
        {
            Name = name;
        }

        

        /// <summary>
        /// Выводит на экран "Имя: мяу!".
        /// Реализация интерфейса IMeowable.
        /// </summary>
        public void Meow()
        {
            Console.WriteLine($"{Name}: мяу!");
        }


        /// <summary>
        /// Метод, вызывающий многократное мяуканье.
        /// Выводит на экран: "Имя: мяу-мяу-…-мяу!" (N раз).
        /// </summary>
        /// <param name="N">Количество раз, которое кот должен помяукать.</param>
        public void Meow(int N) // Meow(int N)
        {
            if (N <= 0)
            {
                Console.WriteLine($"Ошибка: {_name} не может мяукать {N} раз.");
                return;
            }

            string meowPart = "мяу-";

            // Инициализируем StringBuilder для эффективной конкатенации
            StringBuilder sb = new StringBuilder(meowPart.Length * N);

            // Добавляем "мяу-" N раз
            sb.Insert(0, meowPart, N);

            // Убираем последний дефис и добавляем восклицательный знак
            string repeatedString = sb.ToString()[..^1] + "!";

            Console.WriteLine($"{_name}: {repeatedString}");
        }


        /// <summary>
        /// Возвращает текстовое представление кота в формате "кот: Имя".
        /// </summary>
        /// <returns>Строка вида "кот: Имя".</returns>
        public override string ToString()
        {
            return $"кот: {Name}";
        }

    }
}