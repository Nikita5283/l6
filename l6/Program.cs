using System;
using System.Collections.Generic;

namespace l6
{
    internal class Program
    {
        /// <summary>
        /// Основная точка входа в программу. Выполняет тестирование всех заданий лабораторной работы.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1: Кот и мяуканье");

            // Создайте кота по имени "Барсик" (передаем пустую строку, чтобы сработала логика проверки)
            Cat barsik = new Cat("");
            Console.WriteLine($"Создан кот: {barsik.Name}");

            // Барсик мяукает 1 раз
            barsik.Meow();

            // три раза
            barsik.Meow(3);

            // Создадим другого кота для Задания 2 и 3
            Cat kuzya = new Cat("Кузя");

            Console.WriteLine("\nЗадание 2: Интерфейс Мяуканье");

            // Создаем список IMeowable объектов
            List<IMeowable> meowables = new List<IMeowable> { barsik, kuzya };

            // Создадим любой другой произвольный класс, реализующий IMeowable
            IMeowable fakeCat = new OtherMeowable("Друг");
            meowables.Add(fakeCat);

            // Тестируем метод, принимающий набор объектов, способных мяукать
            Funs.MeowsCare(meowables); // Каждый помяукает 5 раз (см. Funs.cs)

            Console.WriteLine("\nЗадание 3: Количество мяуканий");

            // 1. Создаем кота, которого нельзя менять
            Cat originalCat = new Cat("Макс");

            // 2. Оборачиваем кота в наш счетчик (паттерн Декоратор)
            // MeowableCounter counter = m; // m = ...
            MeowableCounter counter = new MeowableCounter(originalCat);

            // 3. Создаем список для передачи. Теперь передаем только наш счетчик.
            List<IMeowable> counterList = new List<IMeowable> { counter };

            // 4. Отправляем обертку в метод (он заставит его мяукать 5 раз)
            Funs.MeowsCare(counterList); // Funs.meowsCare(m)

            // 5. После окончания работы метода, выводим значение счетчика из обертки
            // System.out.println(...)
            Console.WriteLine($"\n{originalCat.Name} мяукал {counter.MeowCount} раз.");

            Console.ReadKey();
        }
    }

    /// <summary>
    /// Произвольный класс для демонстрации Задания 2.
    /// </summary>
    internal class OtherMeowable : IMeowable
    {
        private readonly string _name;
        public OtherMeowable(string name) 
        { 
            _name = name; 
        }

        /// <summary>
        /// Реализация мяуканья для демонстрационного класса.
        /// </summary>
        public void Meow()
        {
            Console.WriteLine($"{_name}: *гав* (но я умею мяукать!)");
        }
    }
}