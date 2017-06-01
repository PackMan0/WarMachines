namespace WarMachines.Commands
{
    using System.Collections.Generic;
    using Providers;

    public interface ICommand
    {
        string ExecuteCommand(ICollection<string> args);
    }
}
