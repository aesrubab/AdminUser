using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Notification
    {
        public int Id { get; internal set; }
        public string Text { get; internal set; }
        public DateTime DateTime { get; internal set; }
        public User FromUser { get; internal set; }
    }
}
