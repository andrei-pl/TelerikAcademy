namespace Computers.UI.Console
{
    using System;
    using System.Collections.Generic;

    public class HP : Manufacturer
    {
        private const int HPPcRam = 2;
        private const int HPLaptopRam = 4;
        private const int HPServerRam = 32;
        private const int TwoCores = 2;
        private const int EightCores = 8;
        private const int ComputerBitsCpu = 32;
        private const int ServerBitsCpu = 32;
        private const int LaptopBitsCpu = 64;

        public HP()
        {
            this.computerRam = new RAM(HPPcRam);
            this.computerVideoCard = new HDD() { IsMonochrome = false };
            this.computerCpu = new Processor(TwoCores, ComputerBitsCpu, this.computerRam, this.computerVideoCard);
            this.computerHdd = new List<HDD> { new HDD(500, false, 0) };

            this.serverRam = new RAM(HPServerRam);
            this.serverVideoCard = new HDD();
            this.serverCpu = new Processor(EightCores, ServerBitsCpu, this.serverRam, this.serverVideoCard);
            this.serverHdd = new List<HDD>
                    {
                        new HDD(0, true, 2, new List<HDD> { new HDD(1000, false, 0), new HDD(1000, false, 0) })
                    };

            this.laptopVideoCard = new HDD() { IsMonochrome = false };
            this.laptopRam = new RAM(HPLaptopRam);
            this.laptopCpu = new Processor(TwoCores, LaptopBitsCpu, this.laptopRam, this.laptopVideoCard);
            this.laptopHdd = new List<HDD> { new HDD(500, false, 0) };
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
