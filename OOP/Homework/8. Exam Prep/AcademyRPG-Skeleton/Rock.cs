using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Rock : StaticObject, IResource
    {
        public Rock(int hitpoints, Point position)
            : base(position)
        {
            this.HitPoints = hitpoints;
            this.Size = hitpoints / 2;
        }

        protected int Size { get; private set; }

        public int Quantity
        {
            get { return this.Size; }
        }

        public ResourceType Type
        {
            get { return ResourceType.Stone; }
        }
    }
}
