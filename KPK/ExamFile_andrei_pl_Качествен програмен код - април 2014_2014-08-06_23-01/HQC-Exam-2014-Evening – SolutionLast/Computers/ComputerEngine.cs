namespace Computers.UI.Console
{
    using System;
    using System.Collections.Generic;

    public class ComputerEngine
    {
        private static IComputer computer, laptop, server;

        public void Run()
        {
            var manufacturer = Console.ReadLine();
            Manufacturer absractFactoryManufacturer;

            if (manufacturer == "HP")
            {
                absractFactoryManufacturer = new HP();
            }
            else if (manufacturer == "Dell")
            {
                absractFactoryManufacturer = new Dell();
            }
            else if (manufacturer == "Lenovo")
            {
                absractFactoryManufacturer = new Lenovo();
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            computer = absractFactoryManufacturer.MakeComputer();
            server = absractFactoryManufacturer.MakeServer();
            laptop = absractFactoryManufacturer.MakeLaptop();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == null || command.StartsWith("Exit"))
                {
                    break;
                }

                var commandLine = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandLine.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var commandName = commandLine[0];
                var commandArgument = int.Parse(commandLine[1]);

                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == "Process")
                {
                    server.Proccess(commandArgument);
                }
                else if (commandName == "Play")
                {
                    computer.Play(commandArgument);
                }
            }
        }
    }
}