using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroTable
{
    public partial class MicroTable : Form
    {
        public MicroTable()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client(tbNameClient.Text);
            Room room = new Room(tbBuilding.Text, tbRoom.Text);
            Counter counter = new Counter(tbNumber.Text, double.Parse(tbRatio.Text));
            Record record = new Record(double.Parse(tbValue.Text), dtpRecords.Value);
            counter.records.Add(record);
            room.counters.Add(counter);
            client.roomsClient.Add(room);

            DbWorker dbWorker = new DbWorker();
            dbWorker.createClientsTable();
            dbWorker.createCountersTable();
            dbWorker.createRecordsTable();
            dbWorker.createRoomsTable();

            dbWorker.insertClientsTable(client);

        }
        private List<Client> Clients { get; set; } = new List<Client>();
        private List<Room> Rooms { get; set; } = new List<Room>();
        private List<Counter> Counters { get; set; } = new List<Counter>();

        private List<Client> dbRead()
        {
            DbWorker dbWorker = new DbWorker();
            List<Client> clients = new List<Client>();
            clients.AddRange(dbWorker.selectClientsTable());
            return clients;
        }

        private List<Room> dbReadAllRooms()
        {
            DbWorker dbWorker = new DbWorker();
            List<Room> rezult = new List<Room>();
            rezult.AddRange(dbWorker.selectAllRoomsTable());
            return rezult;
        }

        private List<Counter> dbReadAllCounter()
        {
            DbWorker dbWorker = new DbWorker();
            List<Counter> rezult = new List<Counter>();
            rezult.AddRange(dbWorker.selectAllCountersTable());
            return rezult;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {

            foreach (Client client in Clients)
            {
                richTextBox1.Text += client.name+"\r\n";
                foreach (Room room in client.roomsClient)
                {
                    richTextBox1.Text += room.building + " " + room.room+"\r\n";
                    foreach (Counter counter in room.counters)
                    {
                        richTextBox1.Text += counter.number + " " + counter.ratio + "\r\n";
                        foreach (Record record in counter.records)
                            richTextBox1.Text += record.ID + " " + record.date.ToString() + " " + record.value;
                    }
                }
            } 
        }

        private enum EnListBox { Rooms, Counters, Records };
        private EnListBox enListBox = EnListBox.Rooms;
        private void button1_Click_1(object sender, EventArgs e)
        {
            NamesTables.Text = "Все помещения";
            enListBox = EnListBox.Rooms;
            FindCaseClients("");
            VisibleElements();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NamesTables.Text = "Все счетчики";
            enListBox = EnListBox.Counters;
            Rooms=dbReadAllRooms();
            FindCaseRooms("");
            VisibleElements();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NamesTables.Text = "Все показания";
            enListBox = EnListBox.Records;
            Counters = dbReadAllCounter();
            FindCaseCounters("");
            VisibleElements();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            switch (enListBox)
            {
                case EnListBox.Rooms:
                    {
                        FindCaseClients(tbSearch.Text);
                        break;
                    }
                case EnListBox.Counters:
                    {
                        FindCaseRooms(tbSearch.Text);
                        break;
                    }
                case EnListBox.Records:
                    {
                        FindCaseCounters(tbSearch.Text);
                        break;
                    }
            }
            
        }

        //поиск по частичному совпадению без учета регистра в списке Арендаторов
        public void FindCaseClients(string s)
        {
            listBox1.Items.Clear();
            foreach (Client item in Clients)
            {
                if (item.name.ToLower().IndexOf(s.ToLower()) > -1) listBox1.Items.Add(item.name);
            }
        }

        //поиск по частичному совпадению без учета регистра в списке помещений
        public void FindCaseRooms(string s)
        {
            listBox1.Items.Clear();
            foreach (Room item in Rooms)
            {
                if (item.ToString().ToLower().IndexOf(s.ToLower()) > -1) listBox1.Items.Add(item.ToString());
            }
        }

        //поиск по частичному совпадению без учета регистра в списке счетчиков
        public void FindCaseCounters(string s)
        {
            listBox1.Items.Clear();
            foreach (Counter item in Counters)
            {
                if (item.number.ToLower().IndexOf(s.ToLower()) > -1) listBox1.Items.Add(item.number);
            }
        }

        //заполнить lb2 значениями помещений
        private void FillLB2Rooms(string NameClient)
        {
            listBox2.Items.Clear();
            foreach (Client client in Clients)
            {
                if (client.name == NameClient)
                {
                    foreach (Room room in client.roomsClient)
                    {
                        listBox2.Items.Add(room.ToString());
                    }
                    break;
                }
            }
        }

        //заполнить lb2 значениями счетчиков
        private void FillLB2Counters(string NameRoom, List<Room> rooms)
        {
            listBox2.Items.Clear();            
            foreach (Room r in rooms)
            {
                if (r.ToString() == NameRoom)
                {
                    foreach (Counter c in r.counters)
                    {
                        listBox2.Items.Add(c.number);
                    }
                    break;
                }
            }
        }

        //заполнить lb2 значениями показаний
        private void FillLB2Records(string NumberCounter, List<Counter> counters)
        {
            listBox2.Items.Clear();
            foreach (Counter c in counters)
            {
                if (c.number == NumberCounter)
                {
                    HINTRoom(c);
                    foreach (Record r in c.records)
                    {
                        listBox2.Items.Add(r.ToString());
                    }
                    break;
                }
            }
        }

        private void HINTRoom(Counter counter)
        {
            DbWorker dbWorker = new DbWorker();
            Room room = dbWorker.selectRoomOnCounterID(counter.ID);
            labelRoom.Text = room.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clients = dbRead();
            FindCaseClients("");
            dtpRecords.Value = DateTime.Now;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            switch (enListBox)
            {
                case (EnListBox.Rooms):
                    {
                        FillLB2Rooms(listBox1.SelectedItem.ToString());                     //выбраны арендаторы
                        break;
                    }
                case (EnListBox.Counters):
                    {
                        FillLB2Counters(listBox1.SelectedItem.ToString(), Rooms);           //выбраны помещения
                        break;
                    }
                case (EnListBox.Records):
                    {
                        FillLB2Records(listBox1.SelectedItem.ToString(), Counters);         //выбраны счетчики
                        break;
                    }
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (enListBox)
            {
                case (EnListBox.Rooms):
                    {
                        enListBox=EnListBox.Counters;
                        NamesTables.Text = "Счетчики:";
                        Rooms.Clear();
                        foreach (Client item in Clients)
                        {
                            if (item.name == listBox1.SelectedItem.ToString())
                            {
                                foreach (Room room in item.roomsClient)
                                {
                                    if (room.ToString() == Selected())
                                    {
                                        Rooms.Add(room);
                                        listBox1.Items.Clear();
                                        listBox1.Items.Add(room.ToString());
                                        break;
                                    } 
                                }
                                break;
                            }
                        }
                        listBox1.SelectedIndex = 0;
                        break;
                    }
                case (EnListBox.Counters):
                    {
                        enListBox=EnListBox.Records;
                        NamesTables.Text = "Показания:";
                        Counters.Clear();
                        foreach (Room item in Rooms)
                        {
                            if (item.ToString() == listBox1.SelectedItem.ToString())
                            {
                                foreach (Counter counter in item.counters)
                                {
                                    if (counter.number == Selected())
                                    {
                                        Counters.Add(counter);
                                        listBox1.Items.Clear();
                                        listBox1.Items.Add(counter.number);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        listBox1.SelectedIndex = 0;
                        
                        break;
                    }
                case (EnListBox.Records):
                    {
                        //no
                        break;
                    }
            }
            VisibleElements();
        }

        // заглушка от случайного клика по пустому полю listbox2 (выбирает первый индекс, при его наличии)
        private string Selected()
        {
            if (listBox2.SelectedItem == null && listBox2.Items.Count > 0) return listBox2.Items[0].ToString();
            else return listBox2.SelectedItem.ToString();
        }
        private void tbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.Clear();
        }

        private void VisibleElements()
        {
            switch (enListBox)
            {
                case EnListBox.Rooms:
                    {
                        VisibleRecords(false);
                        break;
                    }
                case EnListBox.Counters:
                    {
                        VisibleRecords(false);
                        break;
                    }
                case EnListBox.Records:
                    {
                        VisibleRecords(true);
                        break;
                    }
            }
        }

        private void VisibleRecords(bool Status)
        {
            dtpRecords.Visible = Status;
            tbValue.Visible = Status;
        }

        //найти по номеру выделенный счетчик в listbox1
        private Counter SelectedCounter()
        {
            string Number = listBox1.SelectedItem.ToString();
            Counter rezult = new Counter();
            int pos = 0;
            for (int i = 0; i <= listBox1.SelectedIndex; i++)
            {
                if (listBox1.Items[i].ToString() == Number)
                {
                    pos++;
                }
            }
            foreach (Counter counter in Counters)
            {
                if (counter.number == Number)
                {
                    pos--;
                    if (pos == 0) return counter;
                }
            }
            return rezult;
        }

        private Record SelectedRecord(Counter counter)
        {
            return counter.records[listBox2.SelectedIndex];
        }

        private void btnWriteRecord_Click(object sender, EventArgs e)
        {
            Counter counter = SelectedCounter();

            Record record = new Record(double.Parse(tbValue.Text), dtpRecords.Value);
            DbWorker dbWorker = new DbWorker();
            long IDrecord = DateHave(dtpRecords.Value, counter.records);
            if (IDrecord>0)
            {
                record.ID = IDrecord;
                dbWorker.updateRecord(record);                  //обновим данные на существующую дату
            }
            else
            {
                counter.records.Add(record);                    //если на указанную дату нет данных, добавим новую дату и данные.
                dbWorker.insertRecordsTable(record, counter.ID);
            }
            Clients=dbRead();
            counter = dbWorker.selectCounter(counter.ID);
            listBox2.Items.Clear();
            foreach (Record r in counter.records)
            {
                listBox2.Items.Add(r.ToString());
            }
        }
        private long DateHave(DateTime Date, List<Record> records)
        {
            foreach (Record r in records)
            {
                if (r.date.Date == Date.Date) return r.ID;
            }
            return 0;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Counter counter = SelectedCounter();
            Record record = SelectedRecord(counter);

            DbWorker dbWorker = new DbWorker();
            dbWorker.deleteRecord(record);
            counter.records = dbWorker.selectRecordsTable(counter.ID);
            Clients = dbRead();
            
            listBox2.Items.Clear();
            foreach (Record r in counter.records)
            {
                listBox2.Items.Add(r.ToString());
            }
        }

        private void LoadTXTtoDB_Click(object sender, EventArgs e)
        {
            TextToDB dB = new TextToDB();
            DbWorker dbWorker = new DbWorker();
            List<RoomTXT> roomsTXT = dB.Convert(@"Data.txt");
            foreach (RoomTXT roomTXT in roomsTXT)
            {
                if(roomTXT.data!= ";;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;")
                dbWorker.insertClientsTable(roomTXT.ToClient());
            }
        }

        private void TEST_Click(object sender, EventArgs e)
        {
            Record record = new Record();
            record.date = dtpRecords.Value;



            richTextBox1.Text+= DateTimeOffset.Parse(record.date.ToString()).ToUnixTimeSeconds() + "\r\n";
            richTextBox1.Text += record.date.ToString() + "\r\n";
            record.dateInt = DateTimeOffset.Parse(record.date.ToString()).ToUnixTimeSeconds();
            richTextBox1.Text += DateTimeOffset.Parse(record.date.ToString()).ToUnixTimeSeconds() + "\r\n";
            richTextBox1.Text += record.date.ToString() + "\r\n";


            int date = Convert.ToInt32(dtpRecords.Value.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            richTextBox1.Text += date.ToString() + "\r\n";

            record.date = new DateTime(1970, 1, 1).AddSeconds(date);
            richTextBox1.Text += record.date.ToString() + "\r\n";
        }
    }
}
