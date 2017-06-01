namespace WarMachines
{
    using System.Collections.Generic;

    public interface IInputParser
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}
