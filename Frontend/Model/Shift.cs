using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.obj.Model
{
    public class Shift
    {
        public int Id { get; set; }
        public int Duration {get; set;}
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name { get; set; }
    }
}
