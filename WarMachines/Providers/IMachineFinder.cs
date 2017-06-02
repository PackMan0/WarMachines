namespace WarMachines.Providers
{
    using Models;

    public interface IMachineFinder
    {
        IMachine FindMachine(string name);
    }
}
