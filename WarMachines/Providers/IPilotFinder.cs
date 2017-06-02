namespace WarMachines.Providers
{
    using Models;

    public interface IPilotFinder
    {
        IPilot FindPilot(string name);
    }
}
