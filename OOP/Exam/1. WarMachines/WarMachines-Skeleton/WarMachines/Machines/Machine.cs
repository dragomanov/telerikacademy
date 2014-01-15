namespace WarMachines.Machines
{
    using WarMachines.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    abstract class Machine : IMachine
    {
        protected double attackPoints;
        protected double defensePoints;
        protected IList<string> targets;

        public Machine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.attackPoints = attackPoints;
            this.defensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }

        public string Name { get; set; }

        public IPilot Pilot { get; set; }

        public double HealthPoints { get; set; }

        public double AttackPoints
        {
            get { return this.attackPoints; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string targetsStr = this.targets == null || this.targets.Count == 0 ? "None" : string.Join(", ", this.targets);

            sb.AppendLine();
            sb.AppendLine("- " + this.Name);
            sb.AppendLine(" *Type: " + this.GetType().Name);
            sb.AppendLine(" *Health: " + this.HealthPoints);
            sb.AppendLine(" *Attack: " + this.attackPoints);
            sb.AppendLine(" *Defense: " + this.defensePoints);
            sb.AppendLine(" *Targets: " + targetsStr);

            return sb.ToString();
        }
    }
}
