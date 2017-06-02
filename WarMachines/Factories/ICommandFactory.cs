namespace WarMachines.Factories
{
    using Commands;

    public interface ICommandFactory
    {
        ICommand GeCommand();
    }
}
