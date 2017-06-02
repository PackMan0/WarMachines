namespace WarMachines.Providers
{
    using System;

    public class InputOutputProvider : IInputOutputProvider
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }

        public string Read()
        {
           return Console.ReadLine();
        }
    }
}
