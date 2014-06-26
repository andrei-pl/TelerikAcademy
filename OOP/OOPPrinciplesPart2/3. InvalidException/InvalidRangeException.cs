using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.InvalidException
{
    class InvalidRangeException<T> : Exception
    {
        private T start;
        private T end;

        public T Start
        {
            get
            {
                return start;
            }
        }

        public T End
        {
            get
            {
                return end;
            }
        }

        public InvalidRangeException(T start, T end)
            : this(null, start, end, null)
        {
        }

        public InvalidRangeException(string message, T start, T end, Exception ex)
            : base(message, ex)
        {
            this.start = start;
            this.end = end;
        }

        public InvalidRangeException(string message, T start, T end)
            : this(message, start, end, null)
        {
        }
    }
}
