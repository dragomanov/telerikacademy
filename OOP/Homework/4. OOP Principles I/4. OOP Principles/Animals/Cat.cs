﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    class Cat : Animal, ISound
    {
        public Cat(int age, string name, char sex)
            : base(age, name, sex)
        {

        }

        public virtual void ProduceSound()
        {
            Console.WriteLine("Miau miau!");
        }
    }
}
