namespace WarMachines.Providers
{
    using Models;

    public interface IFighterFinder
    {
        IFighter FindFighter(string name);
    }
}
