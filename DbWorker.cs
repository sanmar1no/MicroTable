using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.Data;
using Dapper;


namespace MicroTable
{
    class DbWorker
    {
        private static string dataSource = "MyMicroTableDB.db";
        public DbWorker()
        {
            createClientsTable();
            createCountersTable();
            createRecordsTable();
            createRoomsTable();
        }
        //метод выполняет запрос к БД SQLite
        private void ExecuteQuery(string Query)
        {
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                db.Execute(Query);
            }
        }
        //Метод создаёт таблицу rooms в БД, если её ещё не было
        public void createRoomsTable()
        {
            string s = "CREATE TABLE IF NOT EXISTS rooms (" +
                                "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                "building TEXT NOT NULL," +                             
                                "room TEXT NOT NULL," +
                                "clientID TEXT NOT NULL"+
                                ");";

            ExecuteQuery(s);
        }

        //Метод создаёт таблицу counters в БД, если её ещё не было
        public void createCountersTable()
        {
            string s = "CREATE TABLE IF NOT EXISTS counters (" +
                                "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                "number TEXT NOT NULL," +
                                "ratio REAL NOT NULL," +
                                "roomID INTEGER NOT NULL" +                                
                                ");";

            ExecuteQuery(s);
        }

        //Метод создаёт таблицу records в БД, если её ещё не было
        public void createRecordsTable()
        {
            string s = "CREATE TABLE IF NOT EXISTS records (" +
                                "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                "date INTEGER NOT NULL," +
                                "value REAL NOT NULL," +
                                "counterID INTEGER NOT NULL" +
                                ");";

            ExecuteQuery(s);
        }

        //Метод создаёт таблицу clients в БД, если её ещё не было
        public void createClientsTable()
        {
            string s = "CREATE TABLE IF NOT EXISTS clients (" +
                                "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                "name TEXT NOT NULL UNIQUE" +
                                ");";

            ExecuteQuery(s);
        }

        //Метод вставляет данные в таблицу clients из одного объекта Client
        public void insertClientsTable(Client c)
        {
            string s1 = $"SELECT id FROM clients WHERE name = '{c.name}'";
            string s2 = "INSERT INTO clients (" +
                "name) VALUES" +
                $"('{c.name}'); SELECT last_insert_rowid()";
            long ID = -1;
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                if(db.Query<long>(s1).Count()!=0)ID = db.Query<long>(s1).Last();
            }
            if (ID == -1)
            {
                using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
                {
                    ID = db.Query<long>(s2).Last();
                }
            }
            foreach (Room r in c.roomsClient)
                insertRoomsTable(r,ID);
        }

        //Метод вставляет данные в таблицу rooms из одного объекта Room
        public void insertRoomsTable(Room r, long clientID)
        {
            string s = "INSERT INTO rooms (" +
                "building, room, clientID) VALUES" +
                $"('{r.building}', '{r.room}','{clientID}'); SELECT last_insert_rowid()";

            long ID = -1;
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                ID = db.Query<long>(s).Last();
            }            
            foreach (Counter c in r.counters)
                insertCountersTable(c,ID);
        }

        //Метод вставляет данные в таблицу counters из одного объекта Counter
        public void insertCountersTable(Counter c, long roomID)
        {
            string s = "INSERT INTO counters (" +
                "number, ratio, roomID) VALUES" +
                $"('{c.number}', '{c.ratio}','{roomID}'); SELECT last_insert_rowid()";

            long ID = -1;
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                ID = db.Query<long>(s).Last();
            }
            foreach (Record r in c.records)
                insertRecordsTable(r,ID);
        }

        //Метод вставляет данные в таблицу records из одного объекта Record
        public void insertRecordsTable(Record r, long counterID)
        {

            string s = "INSERT INTO records (" +
                "date, value, counterID) VALUES" +
                //$"('{DateTimeOffset.Parse(r.date.ToString()).ToUnixTimeSeconds()}', '{r.value}','{counterID}');";
                $"('{r.dateInt}', '{r.value}','{counterID}');";
            ExecuteQuery(s);
        }

        //Метод вытаскивает все данные по арендаторам из таблицы clients из БД и возвращает заполненный объект List<Client>
        public List<Client> selectClientsTable()
        {
            List<Client> rezult = new List<Client>();
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                rezult.AddRange(db.Query<Client>("SELECT * FROM clients").ToList());
            }
            foreach (Client client in rezult)
            {
                client.roomsClient.AddRange(selectRoomsTable(client.ID));
            }
            return rezult;
        }

        //Метод вытаскивает данные по арендатору из таблицы rooms из БД и возвращает заполненный объект List<Room>
        public List<Room> selectRoomsTable(long clientID)
        {
            List<Room> rezult = new List<Room>();
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                object Param = clientID;
                rezult.AddRange(db.Query<Room>(@"SELECT * FROM rooms WHERE clientID=@Param;",new { Param }).ToList());
            }
            foreach (Room room in rezult)
            {
                room.counters.AddRange(selectCountersTable(room.ID));
            }
            return rezult;
        }
        public List<Room> selectAllRoomsTable()
        {
            List<Room> rezult = new List<Room>();
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                rezult.AddRange(db.Query<Room>(@"SELECT * FROM rooms").ToList());
            }
            foreach (Room room in rezult)
            {
                room.counters.AddRange(selectCountersTable(room.ID));
            }
            return rezult;
        }

        //Найти помещение, в котором установлен указанный счетчик (по ID счетчика)
        public Room selectRoomOnCounterID(long CounterID)
        {
            Room rezult = new Room();
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                object Param = CounterID;
                rezult = db.Query<Room>(@"SELECT * FROM rooms WHERE id IN (SELECT roomID FROM counters WHERE id =@Param)", new { Param }).First();
            }
            rezult.counters.AddRange(selectCountersTable(rezult.ID));
            return rezult;
        }

        public List<Counter> selectCountersTable(long roomID)
        {

            List<Counter> rezult = new List<Counter>();
            object Param = roomID;
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                rezult.AddRange(db.Query<Counter>(@"SELECT * FROM counters WHERE roomID=@Param;",new { Param }).ToList());
            }
            foreach (Counter counter in rezult)
            {
                counter.records.AddRange(selectRecordsTable(counter.ID));
            }
            return rezult;
        }
        public List<Counter> selectAllCountersTable()
        {

            List<Counter> rezult = new List<Counter>();
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                rezult.AddRange(db.Query<Counter>(@"SELECT * FROM counters WHERE number <>''").ToList());
            }
            foreach (Counter counter in rezult)
            {
                counter.records.AddRange(selectRecordsTable(counter.ID));
            }
            return rezult;
        }
        public Counter selectCounter(long counterID)
        {
            Counter rezult = new Counter();
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                rezult = db.Query<Counter>(@"SELECT * FROM counters 
                    WHERE ID=@counterID", new { counterID }).First();
            }
            rezult.records.AddRange(selectRecordsTable(rezult.ID));
            return rezult;
        }
        public List<Record> selectRecordsTable(long countersID)
        {
            object Param = countersID;
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;new=False;datetimeformat=CurrentCulture"))
            {
                return db.Query<Record>(@"SELECT s.ID, s.date AS dateInt, s.value FROM
                (SELECT r.ID, r.date, r.value FROM records AS r 
                    WHERE counterID=@Param ORDER BY r.date ASC) AS s", new { Param }).ToList();

            }
        }
        // UPDATE
        //Метод, меняющий имя в таблице clients по номеру ID
        public void updateClient(Client client)
        {
            string Name = client.name;
            long Param = client.ID;
            //List<Room> rooms = client.roomsClient; //обновлять?
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                db.Execute(@"UPDATE clients SET name=@Name WHERE ID=@Param", new { Name, Param });
            }
        }

        //Метод, меняющий имя в таблице rooms по номеру ID
        public void updateRoom(Room r)
        {
            string Building = r.building;
            string Room = r.room;
            long Param = r.ID;
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                db.Execute(@"UPDATE rooms SET building=@Building, room=@Room WHERE ID=@Param", new { Building,Room, Param });
            }
        }

        //Метод, меняющий имя в таблице counters по номеру ID
        public void updateCounter(Counter c)
        {
            string Number = c.number;
            double Ratio = c.ratio;
            long Param = c.ID;
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;"))
            {
                db.Execute(@"UPDATE counters SET number=@Number, ratio=@Ratio WHERE ID=@Param", new { Number, Ratio, Param });
            }
        }

        //Метод, меняющий значение в таблице records по номеру ID
        public void updateRecord(Record r)
        {
            long Date = r.dateInt; //дата хранится как long
            double Value = r.value;
            long Param = r.ID;
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;new=False;datetimeformat=CurrentCulture"))
            {
                db.Execute(@"UPDATE records SET date=@Date, value=@Value WHERE ID=@Param", new { Date, Value, Param });
            }
        }
        //DELETE
        //Метод, удаляющий значение в таблице records по номеру ID
        public void deleteRecord(Record r)
        {
            long Param = r.ID;
            using (IDbConnection db = new SQLiteConnection($"Data Source={dataSource};Version=3;new=False;datetimeformat=CurrentCulture"))
            {
                db.Execute(@"DELETE FROM records WHERE ID=@Param", new {Param});
            }
        }
    }
}
