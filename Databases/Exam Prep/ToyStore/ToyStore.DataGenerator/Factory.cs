using System;
using System.Collections.Generic;
using ToyStore.Models;

namespace ToyStore.DataGenerator
{
    public class Factory
    {


        public dynamic Generate(Type T)
        {
            if (T == typeof(Color))
            {
                return new ColorFactory().Create();
            }
            else if (T == typeof(ToyType))
            {
                return new ToyTypeFactory().Create();
            }
            else if (T == typeof(AgeRange))
            {
                return new AgeRangeFactory().Create();
            }
            else if (T == typeof(Country))
            {
                return new CountryFactory().Create();
            }
            else if (T == typeof(AgeRange))
            {
                return new AgeRangeFactory().Create();
            }
            else
            {
                throw new ArgumentException("The type '" + T + "' is a non-supported factory type!");
            }
        }
    }
}
