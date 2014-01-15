namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    class Fighter : Machine, IFighter
    {
        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints, 200)
        {
            this.stealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get { return this.stealthMode; }
        }

        public void ToggleStealthMode()
        {
            this.stealthMode = this.stealthMode ? false : true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            string stealthModeStr = this.stealthMode ? "ON" : "OFF";

            sb.Append(" *Stealth: " + stealthModeStr);

            return sb.ToString();
        }
    }
}
