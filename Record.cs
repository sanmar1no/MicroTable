using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTable
{
    class Record
    {
        public long ID { get; set; }
        public DateTime date { get; set; }

        public long dateInt
        {
            set
            {
                this.date = new DateTime(1970, 1, 1).AddSeconds(value); //DateTimeOffset.FromUnixTimeSeconds(value).DateTime.ToUniversalTime();
            }
            get
            {
                return Convert.ToInt32(this.date.Date.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            }
        }
        public double value { get; set; }

        public Record() : this(0)
        { 
        }
        public Record(double Value) : this(Value, DateTime.Now)
        { 
        }
        public Record(double Value, DateTime Date)
        {
            this.date = Date;
            this.value = Value;
        }
        public override string ToString()
        {
            string rezult = this.date.ToShortDateString() + ": " + this.value + ";";
            return rezult;
        }
    }
}
