using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l6
{
    /// <summary>
    /// Вспомогательный статический класс для общих функций, связанных с IMeowable.
    /// </summary>
    internal static class Funs
    {
        /// <summary>
        /// Принимает набор мяукающих объектов и вызывает их метод Meow 5 раз.
        /// </summary>
        /// <param name="meowables">Коллекция объектов, реализующих IMeowable.</param>
        public static void MeowsCare(IEnumerable<IMeowable> meowables)
        {
            if (meowables == null)
            {
                throw new ArgumentNullException(nameof(meowables), "Набор мяукающих объектов не может быть null.");
            }

            Console.WriteLine("\nFuns.MeowsCare: Начало работы");
            foreach (var item in meowables)
            {
                // Для демонстрации Задания 3, вызываем Meow 5 раз
                for (int i = 0; i < 5; i++)
                {
                    item.Meow();
                }
            }
            Console.WriteLine("Funs.MeowsCare: Завершено\n");
        }
    }
}