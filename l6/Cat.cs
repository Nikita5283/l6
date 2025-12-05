using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace l6
{
    internal class Cat
    {
        private string name;
        public string Name
        {
            get { return $"кот: {name}"; }
            set
            {
                if (value != "" || value != null)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Ошибка имени");
                    name = "";
                }
            }
        }

        public Cat(string name)
        {
            Name = name;
        }
    }
}
