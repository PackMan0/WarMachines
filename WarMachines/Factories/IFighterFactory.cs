namespace WarMachines.Factories
{
    using Interfaces;

    public interface IFighterFactory
    {
        IFighter CreateFighter(string name, int attackPoints, int defensePoints, bool initialStealthMode);
    }
}
