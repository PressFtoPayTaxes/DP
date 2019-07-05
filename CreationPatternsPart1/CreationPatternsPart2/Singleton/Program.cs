using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Connection // Singleton
    {
        private Connection()
        {
               
        }
        private static Connection _connection;
        public static Connection GetConnection()
        {
            if(_connection == null)
            {
                _connection = new Connection();
            }
            return _connection;
        }

        public void ConnectToDatabase()
        {
            Console.WriteLine("Connection: Connected!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Connection connection1 = Connection.GetConnection();
            Connection connection2 = Connection.GetConnection();

            if(connection1 == connection2)
            {
                connection1.ConnectToDatabase();
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}
