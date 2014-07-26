namespace Singleton
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var singleton1 = Singleton.Instance;
            var singleton2 = Singleton2.Instance;
            var singleton3 = Singleton3.Instance;
        }
    }

    // most simple implementation
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
    }

    // allows only a single thread to enter the critical area, which the lock block identifies, 
    // when no instance of Singleton has yet been created
    public sealed class Singleton2
    {
        private static volatile Singleton2 instance;
        private static object syncRoot = new object();

        private Singleton2()
        {
        }

        public static Singleton2 Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton2();
                        }
                    }
                }

                return instance;
            }
        }
    }

    // not thread safe, static initialization - to be avoided
    public class Singleton3
    {
        private static Singleton3 instance;

        private Singleton3()
        {
        }

        public static Singleton3 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton3();
                }

                return instance;
            }
        }
    }
}
