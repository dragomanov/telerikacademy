namespace WarMachines.Machines
{
    using WarMachines.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    class Tank : Machine, ITank
    {
        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, 100)
        {
            this.attackPoints = attackPoints - 40;
            this.defensePoints = defensePoints + 30;
            this.defenseMode = true;
        }

        public bool DefenseMode
        {
            get { return this.defenseMode; }
        }

        public void ToggleDefenseMode()
        {
            if (this.defenseMode)
            {
                this.defenseMode = false;
                this.attackPoints += 40;
                this.defensePoints -= 30;
            }
            else
            {
                this.defenseMode = true;
                this.attackPoints -= 40;
                this.defensePoints += 30;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            string defModeStr = this.defenseMode ? "ON" : "OFF";

            sb.Append(" *Defense: " + defModeStr);

            return sb.ToString();
        }
    }
}
