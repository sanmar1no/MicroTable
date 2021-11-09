using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MicroTable
{
    class TextToDB
    {
        public TextToDB()
        {
        }
        public List<Client> Clients = new List<Client>();
        
        public List<string> FileLoad(string FileName)                       //загрузить @"Data.txt"
        {
            return File.ReadAllLines(FileName, Encoding.Default).ToList();
        }
        public List<RoomTXT> Convert(string FileName)
        {
            List<string> F = FileLoad(FileName);
            List<RoomTXT> RoomsTXT = new List<RoomTXT>();
            int roomsNum=0;
            int floorNum = 0;
            RoomTXT roomTXT = new RoomTXT();
            roomTXT.number = -1;
            bool clientORrecord = true;             //true-пишет Арендаторов, false - пишет счетчики
            for (int i = 1; i < F.Count(); i++)     //начинаем с 1, так как в первой строке хранится количество помещений.
            {
                if (F[i].IndexOf("etaz_") > -1)
                {
                    if (roomTXT.number > -1)
                    {
                        RoomsTXT.Add(roomTXT);
                        roomTXT = new RoomTXT();
                    }
                    floorNum = int.Parse(F[i].Substring(6, F[i].IndexOf("]")-6));
                    i++; //следующая строка - номер помещения
                    roomsNum = 0;
                }
                if (F[i].IndexOf("["+ roomsNum.ToString()+"]") > -1)
                {
                    if (roomsNum != 0)
                    {
                        RoomsTXT.Add(roomTXT);
                        roomTXT = new RoomTXT();
                    }
                    roomTXT.number = roomsNum;
                    roomTXT.floor = floorNum;
                    roomsNum++;
                    i++; //следующая строка - координаты
                    roomTXT.coord = F[i];
                    i++; //следующая строка - основные данные
                    roomTXT.data = F[i];
                    i++;
                    clientORrecord = true;
                }
                if (F[i].IndexOf("[pokazanie]") > -1)
                {
                    clientORrecord = false;
                    i++;
                }
                if (F[i].IndexOf("[") == -1)
                {
                    if (clientORrecord)
                    {
                        roomTXT.clients.Add(F[i]);
                    }
                    else
                    {
                        roomTXT.records.Add(F[i]);
                    }
                }
                else
                {
                    i--;
                } 
            }
            RoomsTXT.Add(roomTXT); //запишем последнюю комнату
            return RoomsTXT;
        }
    }
    class RoomTXT
    {
        public RoomTXT()
        { 
        }
        public int number { get; set; }
        public int floor { get; set; }
        public string coord { get; set; }
        public string data { get; set; }
        public List<string> clients { get; set; } = new List<string>();
        public List<string> records { get; set; } = new List<string>();

        public Client ToClient()
        {            
            Client rezult = new Client(SubStr(clients[0],2));
            rezult.roomsClient.Add(this.ToRoom());
            return rezult;
        }
        public Room ToRoom()
        {
            string building = SubStr(data, 1);
            string room = SubStr(data, 2);
            Room rezult = new Room(building,room);
            rezult.counters.Add(this.ToCounter());
            return rezult;
        }
        public Counter ToCounter()
        {
            string s = SubStr(data, 10);
            string s2 = SubStr(data, 16);
            double ratio = 0;
            if (s2 != "") ratio=double.Parse(s2);
            Counter rezult = new Counter(s, ratio);
            rezult.records.AddRange(ToRecords());
            return rezult;
        }
        public List<Record> ToRecords()
        {
            List<Record> Records = new List<Record>();
            string Number = SubStr(data, 10);
            foreach (string record in records)
            {
                if (SubStr(record, 4) == Number)                        //если номер счетчика последний из установленных
                {
                    DateTime date = DateTime.Parse(SubStr(record, 1));
                    double value = 0;
                    if (SubStr(record, 2) != "") value = double.Parse(SubStr(record, 2));
                    Records.Add(new Record(value, date));
                }
            }
            return Records;
        }

        private string SubStr(string str,int Num)
        {
            if (Num == 1)
            { 
            return str.Substring(0, str.IndexOf(";"));
            }
            for (int i = 0; i < Num-1; i++)
            {
                str = str.Substring(str.IndexOf(";") + 1);
            }
            int pos = str.IndexOf(";");
            if (pos > -1) return str.Substring(0, pos);
            else return str;
        }
    }
}
