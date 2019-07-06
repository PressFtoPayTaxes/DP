using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    interface ICommand
    {
        void Execute();
    }

    class EnterUsername : ICommand // Concrete command
    {
        public void Execute()
        {
            Console.WriteLine("Command: Username entered");
        }
    }

    class SaveToDatabase : ICommand // Concrete command
    {
        private Database _database;
        private string _address;

        public SaveToDatabase(Database database, string address)
        {
            _database = database;
            _address = address;
        }

        public void Execute()
        {
            Console.WriteLine("Command: Connecting to database...");
            _database.Save(_address);
        }
    }

    class Database // Receiver
    {
        public void Save(string address)
        {
            Console.WriteLine($"Database: Saved to database on address {address}");
        }
    }

    class User // Invoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            if (_command != null)
                _command.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EnterUsername enterUsername = new EnterUsername();
            SaveToDatabase save = new SaveToDatabase(new Database(), "this_computer");

            User user = new User();
            user.SetCommand(enterUsername);
            user.ExecuteCommand();
            user.SetCommand(save);
            user.ExecuteCommand();

            Console.ReadLine();
        }
    }
}
