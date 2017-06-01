namespace WarMachines.Factories
{
    using Interfaces;

    public interface IPilotFactory
    {
        IPilot CreatePilot(string name);
    }
}
