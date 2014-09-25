namespace Computers.UI.Console
{
    using System;
    using System.Collections.Generic;

    public class Lenovo : Manufacturer
    {
        private const int LenovoPcRam = 4;
        private const int LenovoLaptopRam = 16;
        private const int LenovoServerRam = 8;
        private const int ComputerCores = 2;
        private const int ServerCores = 2;
        private const int LaptopCores = 2;
        private const int ComputerBitsCpu = 64;
        private const int LaptopBitsCpu = 64;
        private const int ServerBitsCpu = 128;

        public Lenovo()
        {
            this.computerRam = new RAM(LenovoPcRam);
            this.computerVideoCard = new HDD() { IsMonochrome = true };
            this.computerCpu = new Processor(ComputerCores, ComputerBitsCpu, this.computerRam, this.computerVideoCard);
            this.computerHdd = new List<HDD> { new HDD(2000, false, 0) };

            this.serverRam = new RAM(LenovoServerRam);
            this.serverVideoCard = new HDD();
            this.serverCpu = new Processor(ServerCores, ServerBitsCpu, this.serverRam, this.serverVideoCard);
            this.serverHdd = new List<HDD>
                    {
                        new HDD(0, true, 2, new List<HDD> { new HDD(500, false, 0), new HDD(500, false, 0) })
                    };

            this.laptopRam = new RAM(LenovoLaptopRam);
            this.laptopVideoCard = new HDD() { IsMonochrome = false };
            this.laptopCpu = new Processor(LaptopCores, LaptopBitsCpu, this.laptopRam, this.laptopVideoCard);
            this.laptopHdd = new[] { new HDD(1000, false, 0) };
        }

        public override IComputer MakeComputer()
        {
            this.Computer = new Computer(ComputerType.PC, this.computerCpu, this.computerRam, this.computerHdd, this.computerVideoCard, null);

            return this.Computer;
        }

        public override IComputer MakeServer()
        {
            this.Server = new Computer(ComputerType.Server, this.serverCpu, this.serverRam, this.serverHdd, this.serverVideoCard, null);

            return this.Server;
        }

        public override IComputer MakeLaptop()
        {
            this.Laptop = new Computer(ComputerType.Laptop, this.laptopCpu, this.laptopRam, this.laptopHdd, this.laptopVideoCard, new LaptopBattery());

            return this.Laptop;
        }
    }
}
