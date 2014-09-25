namespace Computers.UI.Console
{
    /// <summary>
    /// Abstract Factory
    /// </summary>
    using System;
    using System.Collections.Generic;

    public abstract class Manufacturer : IManufacturer
    {
        protected RAM computerRam;
        protected HDD computerVideoCard;
        protected Processor computerCpu;
        protected IList<HDD> computerHdd;
        protected RAM serverRam;
        protected HDD serverVideoCard;
        protected Processor serverCpu;
        protected IList<HDD> serverHdd;
        protected RAM laptopRam;
        protected HDD laptopVideoCard;
        protected Processor laptopCpu;
        protected IList<HDD> laptopHdd;
        
        protected IComputer Computer { get; set; }

        protected IComputer Server { get; set; }

        protected IComputer Laptop { get; set; }

        public abstract IComputer MakeComputer();

        public abstract IComputer MakeServer();

        public abstract IComputer MakeLaptop();
    }
}
