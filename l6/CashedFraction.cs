using System;

namespace l6
{
    /// <summary>
    /// Версия дроби с кэшированием вещественного значения (Задание 4).
    /// </summary>
    public class CachedFraction : Fraction
    {
        // Nullable double используется как флаг: если null, значит кэш пуст
        private double? _cachedRealValue = null;

        public CachedFraction(int num, int den) : base(num, den) { }

        public override double GetRealValue()
        {
            if (_cachedRealValue.HasValue)
            {
                Console.WriteLine($"Взято из кэша для {this}");
                return _cachedRealValue.Value;
            }

            // Если кэша нет, вызываем базовый метод вычисления (он выведет лог о вычислении)
            var val = base.GetRealValue();

            // Сохраняем в кэш
            _cachedRealValue = val;
            return val;
        }

        public override void SetNumerator(int numerator)
        {
            // Если значение меняется, сбрасываем кэш
            if (numerator != Numerator)
            {
                base.SetNumerator(numerator);
                _cachedRealValue = null;
                Console.WriteLine("Числитель изменен, кэш сброшен.");
            }
        }

        public override void SetDenominator(int denominator)
        {
            if (denominator != Denominator)
            {
                base.SetDenominator(denominator);
                _cachedRealValue = null;
                Console.WriteLine("Знаменатель изменен, кэш сброшен.");
            }
        }
    }
}