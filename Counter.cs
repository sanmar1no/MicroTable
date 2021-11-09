using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTable
{
    class Counter
    {
        public long ID { get; set; }                     //уникальный номер счетчика
        public string number { get; set; }              //номер счетчика
        public double ratio { get; set; } = 1;          //	Коэффициент учета	
        public List<Record> records { get; set; } = new List<Record>();      // показания счетчика

        public Counter() : this("")
        { 
        }
        public Counter(string Number) : this(Number, 1)
        { 
        }
        public Counter(string Number, double Ratio)
        {
            this.number = Number;
            this.ratio = Ratio;
        }
    }
}
