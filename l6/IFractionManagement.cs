namespace l6
{
    /// <summary>
    /// Интерфейс для Задания 4.
    /// Определяет методы изменения состояния и получения вещественного значения.
    /// </summary>
    public interface IFractionManagement
    {
        double GetRealValue();
        void SetNumerator(int numerator);
        void SetDenominator(int denominator);
    }
}