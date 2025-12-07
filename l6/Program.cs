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
            Console.WriteLine("=== Задание 1: Коты ===");
            Console.WriteLine("1. Кот и мяуканье");

            // Создайте кота по имени "Барсик" (передаем пустую строку, чтобы сработала логика проверки)
            Cat barsik = new Cat("");
            Console.WriteLine($"Создан кот: {barsik.Name}");

            // Барсик мяукает 1 раз
            barsik.Meow();

            // три раза
            barsik.Meow(3);

            // Создадим другого кота для Задания 2 и 3
            Cat kuzya = new Cat("Кузя");

            Console.WriteLine("\n2. Интерфейс Мяуканье");

            // Создаем список IMeowable объектов
            List<IMeowable> meowables = new List<IMeowable> { barsik, kuzya };

            // Создадим любой другой произвольный класс, реализующий IMeowable
            IMeowable fakeCat = new OtherMeowable("Друг");
            meowables.Add(fakeCat);

            // Тестируем метод, принимающий набор объектов, способных мяукать
            Funs.MeowsCare(meowables); // Каждый помяукает 5 раз (см. Funs.cs)

            Console.WriteLine("3. Количество мяуканий");

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
            Console.WriteLine($"{originalCat.Name} мяукал {counter.MeowCount} раз.");


            Console.WriteLine("\n=== Задание 2: Дроби ===");

            Console.WriteLine("1. Дроби и Операции");

            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = new Fraction(2, 3);
            Fraction f3 = new Fraction(1, 2);
            Fraction f4 = new Fraction(4, -8); // Проверка знака и сокращения (будет -1/2)

            Console.WriteLine($"Созданы дроби: f1={f1}, f2={f2}, f3={f3}, f4={f4}");

            // Демонстрация операторов и формата вывода
            Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
            Console.WriteLine($"{f1} * {f2} = {f1 * f2}"); // 2/9
            Console.WriteLine($"{f2} - {f3} = {f2 - f3}"); // 4/6 - 3/6 = 1/6
            Console.WriteLine($"{f3} / {f2} = {f3 / f2}"); // 1/2 * 3/2 = 3/4
            Console.WriteLine($"{f2} + 5 = {f2 + 5}");     // С числом

            // Демонстрация цепочки методов (f1.sum(f2).div(f3).minus(5))
            // f1(1/3) + f2(2/3) = 1
            // 1 / f3(1/2) = 2
            // 2 - 5 = -3
            Fraction chainResult = f1.Sum(f2).Div(f3).Minus(5);
            Console.WriteLine($"\nРезультат цепочки f1.sum(f2).div(f3).minus(5): {chainResult}");


            Console.WriteLine("\n2. Сравнение");

            Fraction a = new Fraction(1, 2);
            Fraction b = new Fraction(2, 4); // Сократится до 1/2
            Fraction c = new Fraction(1, 3);

            Console.WriteLine($"{a} равна {b}? -> {a.Equals(b)}"); // True
            Console.WriteLine($"{a} равна {c}? -> {a.Equals(c)}"); // False
            Console.WriteLine($"Хэш-код {a}: {a.GetHashCode()}");
            Console.WriteLine($"Хэш-код {b}: {b.GetHashCode()}");
            Console.WriteLine($"Хэш-код {c}: {c.GetHashCode()}");


            Console.WriteLine("\n3. Клонирование");

            Fraction original = new Fraction(3, 7);
            Fraction clone = (Fraction)original.Clone();

            Console.WriteLine($"Оригинал: {original}, Клон: {clone}");
            Console.WriteLine($"Ссылки равны? -> {ReferenceEquals(original, clone)}"); // False


            Console.WriteLine("\n4. Кэширование");

            // Создаем кэширующую дробь (3/4 = 0.75)
            CachedFraction cachedF = new CachedFraction(3, 4);

            Console.WriteLine("1. Первый вызов GetRealValue (должно быть вычисление):");
            Console.WriteLine($"   Значение: {cachedF.GetRealValue()}");

            Console.WriteLine("2. Второй вызов GetRealValue (должно быть из кэша):");
            Console.WriteLine($"   Значение: {cachedF.GetRealValue()}");

            Console.WriteLine("3. Изменяем знаменатель на 2 (становится 3/2 = 1.5):");
            cachedF.SetDenominator(2);

            Console.WriteLine("4. Третий вызов GetRealValue (после изменения, снова вычисление):");
            Console.WriteLine($"   Значение: {cachedF.GetRealValue()}");

            Console.WriteLine("5. Четвертый вызов (снова кэш):");
            Console.WriteLine($"   Значение: {cachedF.GetRealValue()}");

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