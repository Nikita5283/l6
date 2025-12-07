using System;

namespace l6
{
    /// <summary>
    /// Класс Дробь. Реализует арифметические операции, сравнение и клонирование.
    /// </summary>
    public class Fraction : ICloneable, IFractionManagement
    {
        protected int _numerator;
        protected int _denominator;

        public int Numerator => _numerator;
        public int Denominator => _denominator;

        /// <summary>
        /// Конструктор дроби.
        /// </summary>
        /// <param name="numerator">Числитель</param>
        /// <param name="denominator">Знаменатель (не может быть 0)</param>
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Знаменатель не может быть равен нулю.");

            _numerator = numerator;
            _denominator = denominator;

            Normalize();
        }

        /// <summary>
        /// Приводит дробь к каноническому виду:
        /// 1. Знак минуса всегда у числителя.
        /// 2. Дробь сокращается (например, 2/4 -> 1/2).
        /// </summary>
        private void Normalize()
        {
            // Обработка знака
            if (_denominator < 0)
            {
                _numerator = -_numerator;
                _denominator = -_denominator;
            }

            // Сокращение дроби через НОД
            int gcd = Gcd(Math.Abs(_numerator), Math.Abs(_denominator));
            _numerator /= gcd;
            _denominator /= gcd;
        }

        /// <summary>
        /// Вычисление Наибольшего Общего Делителя (алгоритм Евклида).
        /// </summary>
        private int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            return $"{_numerator}/{_denominator}";
        }

        // Операции (Перегрузка операторов)

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a._numerator * b._denominator + b._numerator * a._denominator, a._denominator * b._denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(a._numerator * b._denominator - b._numerator * a._denominator, a._denominator * b._denominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a._numerator * b._numerator, a._denominator * b._denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction(a._numerator * b._denominator, a._denominator * b._numerator);
        }

        // Перегрузки для целых чисел
        public static Fraction operator +(Fraction a, int b) => a + new Fraction(b, 1);
        public static Fraction operator -(Fraction a, int b) => a - new Fraction(b, 1);
        public static Fraction operator *(Fraction a, int b) => a * new Fraction(b, 1);
        public static Fraction operator /(Fraction a, int b) => a / new Fraction(b, 1);

        // Методы для цепочки (f1.sum(f2).div...)
        // Требуются по заданию для записи вида: f1.sum(f2).div(f3).minus(5)

        public Fraction Sum(Fraction other) => this + other;
        public Fraction Minus(Fraction other) => this - other;
        public Fraction Minus(int other) => this - other; // Перегрузка для числа
        public Fraction Mult(Fraction other) => this * other;
        public Fraction Div(Fraction other) => this / other;

        // Задание 2: сравнение

        /// <summary>
        /// Сравнивает знаменатели и числители дроби от которой вызывается метод и объекта передаваемого в метод
        /// </summary>
        /// /// <param name="obj">Объект, с которым нужно сравнить текущую дробь</param>
        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
            {
                return this._numerator == other._numerator && this._denominator == other._denominator;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_numerator, _denominator);
        }

        // Задание 3: клонирование

        public object Clone()
        {
            return new Fraction(this._numerator, this._denominator);
        }

        // Задание 4: Реализация интерфейса (базовая)

        public virtual double GetRealValue()
        {
            // Вычисляем каждый раз заново
            Console.WriteLine($"Вычисление вещественного значения для {this}...");
            return (double)_numerator / _denominator;
        }

        public virtual void SetNumerator(int numerator)
        {
            _numerator = numerator;
            Normalize(); // Пересчитываем нормализацию при изменении
        }

        public virtual void SetDenominator(int denominator)
        {
            if (denominator == 0) throw new DivideByZeroException();
            _denominator = denominator;
            Normalize();
        }
    }
}