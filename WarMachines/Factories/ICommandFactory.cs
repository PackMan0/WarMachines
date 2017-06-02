namespace WarMachines.Factories
{
    using Commands;
    using Enums;

    public interface ICommandFactory
    {
        ICommand GeCommand(CommandTypes type);
    }
}
