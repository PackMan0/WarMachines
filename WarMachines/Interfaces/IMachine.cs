namespace WarMachines.Interfaces
{
    using System.Collections.Generic;

    public interface IMachine
    {
        string Name { get; set; }

        IPilot Pilot { get; set; }

        int HealthPoints { get; set; }

        int AttackPoints { get; }

        int DefensePoints { get; }

        string ToString();
    }
}
