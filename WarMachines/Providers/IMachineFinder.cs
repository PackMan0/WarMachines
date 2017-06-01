namespace WarMachines.Providers
{
    using Interfaces;

    public interface IMachineFinder
    {
        IMachine FindMachine(string name);
    }
}
