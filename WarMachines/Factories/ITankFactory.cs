namespace WarMachines.Factories
{
    using Models;

    public interface ITankFactory
    {
        ITank CreateTank(string name, int attackPoints, int defensePoints);
    }
}
