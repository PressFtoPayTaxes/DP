using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IDatabase
    {
        void Connect();
    }

    public class Database : IDatabase
    {
        public void Connect()
        {
            Console.WriteLine("Connected to database");
        }
    }

    public class DatabaseProxy : IDatabase
    {
        private Database _database;

        public DatabaseProxy(Database database)
        {
            _database = database;
        }

        public void Connect()
        {
            _database.Connect();
            Console.WriteLine("Logger: Someone connected to database!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Original database:");
            Database database = new Database();
            database.Connect();

            Console.WriteLine("Proxy database:");
            DatabaseProxy proxy = new DatabaseProxy(database);
            proxy.Connect();

            Console.ReadLine();
        }
    }
}
