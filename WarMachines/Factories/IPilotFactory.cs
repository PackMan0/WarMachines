namespace WarMachines.Factories
{
    using Models;

    public interface IPilotFactory
    {
        IPilot CreatePilot(string name);
    }
}
