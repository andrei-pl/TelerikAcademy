namespace Computers.UI.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HDD
    {
        private readonly List<HDD> hardDrives;

        private readonly bool isInRaid;

        private readonly int hardDrivesInRaid;

        private SortedDictionary<int, string> data;
        
        private int capacity;

        internal HDD()
        {
            this.data = new SortedDictionary<int, string>();
        }

        internal HDD(int capacity, bool isInRaid, int hardDrivesInRaid)
            : this(capacity, isInRaid, hardDrivesInRaid, new List<HDD>())
        {
        }

        internal HDD(int capacity, bool isInRaid, int hardDrivesInRaid, IList<HDD> hardDrives)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;

            this.data = new SortedDictionary<int, string>();
            this.hardDrives = new List<HDD>(hardDrives);
        }
        
        public bool IsMonochrome { get; set; }

        private int Capacity
        {
            get
            {
                if (this.isInRaid)
                {
                    if (!this.hardDrives.Any())
                    {
                        return 0;
                    }

                    return this.hardDrives.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }
        }

        public void SaveData(int addr, string newData)
        {
            if (this.isInRaid)
            {
                foreach (var hardDrive in this.hardDrives)
                {
                    hardDrive.SaveData(addr, newData);
                }
            }
            else
            {
                this.data[addr] = newData;
            }
        }

        public string LoadData(int address)
        {
            if (this.isInRaid)
            {
                if (!this.hardDrives.Any())
                {
                    throw new OutOfMemoryException("No hard drive in the RAID array!");
                }

                return this.hardDrives.First().LoadData(address);
            }
            else if (true)
            {
                return this.data[address];
            }
        }

        public void Draw(string a)
        {
            if (this.IsMonochrome)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(a);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(a);
                Console.ResetColor();
            }
        }
    }
}