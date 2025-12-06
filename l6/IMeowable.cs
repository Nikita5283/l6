using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l6
{
    /// <summary>
    /// Интерфейс, представляющий объект, который способен мяукать.
    /// </summary>
    public interface IMeowable
    {
        /// <summary>
        /// Вызывает базовое мяуканье объекта.
        /// </summary>
        public void Meow();
    }
}