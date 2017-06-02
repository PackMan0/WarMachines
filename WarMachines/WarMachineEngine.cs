namespace WarMachines
{
    using System;
    using System.Linq;
    using Enums;
    using Factories;
    using Providers;

    public sealed class WarMachineEngine : IWarMachineEngine
    {
        private readonly IInputOutputProvider _inputOutputProvider;
        private readonly ICommandFactory _commandFactory;

        public WarMachineEngine(IInputOutputProvider inputOutputProvider, ICommandFactory commandFactory)
        {
            this._inputOutputProvider = inputOutputProvider;
            this._commandFactory = commandFactory;
        }

        public void Start()
        {
            while (true)
            {
                var intput = this._inputOutputProvider.Read().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
                CommandTypes commandType;

                if (intput.Count > 0 && Enum.TryParse(intput[0], out commandType))
                {
                    if (commandType == CommandTypes.Exit)
                    {
                        return;
                    }

                    var command = this._commandFactory.GetCommand(commandType);
                    var result = command.ExecuteCommand(intput.GetRange(1, intput.Count - 1));

                    this._inputOutputProvider.Write(result);
                }
                else
                {
                    this._inputOutputProvider.Write("Invalid command.");
                }

            }
        }
       
    }

}
