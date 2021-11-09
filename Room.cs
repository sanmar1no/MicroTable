using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTable
{
    class Room
    {
        public long ID { get; set; }                      //уникальный номер
        public string building { get; set; }             //	№ корпуса/адрес:улица
        public string room { get; set; }                 //	№ помещения/номер дома+помещение
        public List<Counter> counters { get; set; } = new List<Counter>();     //счетчики


        public Room() : this("","")
        { 
        }

        public Room(string Building, string Room)
        {
            this.building = Building;
            this.room = Room;
        }

        public override string ToString()
        {
            string rezult = "Корп.N" + this.building + ", Помещ.N" + this.room + ";";
            return rezult;
        }
    }
}
