namespace WarMachines.Providers
{
    using Models;

    public interface ITankFinder
    {
        ITank FindTank(string name);
    }
}
