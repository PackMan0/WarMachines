namespace WarMachines
{
    using System;
    using System.Collections.Generic;

    public class InputParser : IInputParser
    {
        private const char SplitCommandSymbol = ' ';

        private string name;
        private IList<string> parameters;

        private InputParser(string input)
        {
            this.parameters = new List<string>();
            this.TranslateInput(input);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        public static InputParser Parse(string input)
        {
            return new InputParser(input);
        }

        private void TranslateInput(string input)
        {
            var indexOfFirstSeparator = input.IndexOf(SplitCommandSymbol);

            this.Name = input.Substring(0, indexOfFirstSeparator);
            this.Parameters = input.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
