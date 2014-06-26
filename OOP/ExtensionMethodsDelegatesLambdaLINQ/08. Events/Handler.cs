using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Events
{
    class Handler
    {
        public Handler(Publisher publish)
        {
            publish.RaiseEventFlag += this.CustomEvent;
        }

        public void CustomEvent(object sender, EventArgs e)
        {
            Console.WriteLine("This is a test message!");
        }
    }
}
