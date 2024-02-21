using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brands_DAY39
{
    internal class Brands
    {
        public Brands()
        {
            _count++;
            Id = _count;
        }
        static int _count;
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name} - {Year}";
        }
    }
}
