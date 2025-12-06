using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l6
{
    /// <summary>
    /// Декоратор для IMeowable, который подсчитывает количество вызовов метода Meow.
    /// Класс используется для выполнения Задания 3, когда сам объект Cat изменять нельзя.
    /// </summary>
    public class MeowableCounter : IMeowable
    {
        private readonly IMeowable _meowableObject;

        /// <summary>
        /// Счетчик, хранящий количество вызовов Meow.
        /// </summary>
        public int MeowCount { get; private set; } = 0;

        /// <summary>
        /// Создает новый счетчик для мяукающего объекта.
        /// </summary>
        /// <param name="meowableObject">Объект, чье мяуканье нужно считать.</param>
        public MeowableCounter(IMeowable meowableObject)
        {
            if (meowableObject == null)
            {
                throw new ArgumentNullException(nameof(meowableObject), "Оборачиваемый объект не может быть null.");
            }
            _meowableObject = meowableObject;
        }

        /// <summary>
        /// Вызывает мяуканье у оборачиваемого объекта и увеличивает счетчик.
        /// </summary>
        public void Meow()
        {
            // 1. Вызываем метод у оригинального объекта (Кота)
            _meowableObject.Meow();
            // 2. Увеличиваем счетчик
            MeowCount++;
        }
    }
}