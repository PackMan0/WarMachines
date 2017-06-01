namespace WarMachines.Providers
{
    using Interfaces;

    public interface IPilotFinder
    {
        IPilot FindPilot(string name);
    }
}
