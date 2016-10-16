using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryReferences
{
    class FactoryItem
    {
        public string name;
        public int ID;
        public bool alive;

        public FactoryItem(string name, int ID)
        {
            this.name = name;
            this.ID = ID;
            alive = true;
        }

        public void Destroy()
        {
            alive = false;
        }

        public static bool operator ==(FactoryItem a, FactoryItem b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(FactoryItem a, FactoryItem b)
        {
            return !a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            return (alive & base.Equals(obj));
        }
    }
}
