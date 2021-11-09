using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTable
{
    class Client
    {
        public long ID { get; set; }                 //уникальный номер Арендатора
        public string name { get; set; }            //Наименование организации - арендатора
        public List<Room> roomsClient { get; set; } = new List<Room>();//арендованные помещения
        public Client() : this("")
        { 
        }
        public Client(string Name)
        {
            this.name = Name;
        }
        public Client(string Name, Room room)
        {
            this.name = Name;
            this.roomsClient.Add(room);
        }
    }
}
