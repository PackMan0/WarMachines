namespace WarMachines.Factories
{
    using Models;

    public interface IFighterFactory
    {
        IFighter CreateFighter(string name, int attackPoints, int defensePoints, bool initialStealthMode);
    }
}
