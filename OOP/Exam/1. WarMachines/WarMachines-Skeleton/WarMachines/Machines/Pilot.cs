namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        public string Name { get; private set; }
        IList<IMachine> Machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.Machines = new List<IMachine>();
        }

        public void AddMachine(IMachine machine)
        {
            this.Machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name);
            sb.Append(" - ");

            if (this.Machines == null || this.Machines.Count == 0)
            {
                sb.Append("no machines");
            }
            else
            {
                sb.Append(this.Machines.Count);
                sb.Append(" machine");
                sb.Append(this.Machines.Count > 1 ? "s" : "");

                foreach (var machine in this.Machines)
                {
                    sb.Append(machine);
                }
            }

            return sb.ToString();
        }
    }
}
