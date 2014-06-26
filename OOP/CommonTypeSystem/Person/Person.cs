namespace Person
{
    using System;
    using System.Text;

    class Person
    {
        public Person(string name, byte? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public byte? Age { get; private set; }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine(this.Name);

            if (this.Age == null)
            {
                info.AppendLine("Age not found");
            }
            else
            {
                info.AppendLine(this.Age.ToString());
            }
            return info.ToString();
        }
    }
}
