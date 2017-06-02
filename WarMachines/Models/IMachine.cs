namespace WarMachines.Models
{
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
