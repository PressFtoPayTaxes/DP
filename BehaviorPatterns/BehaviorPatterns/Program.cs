using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    interface IHandler
    {
        IHandler SetNext(IHandler handler);
        void Handle(string request);
    }

    abstract class RegistrationHandler : IHandler // Base handler
    {
        private IHandler _next;

        public virtual void Handle(string request)
        {
            if (_next != null)
                _next.Handle(request);
            else
                Console.WriteLine("Unknown request");
        }

        public IHandler SetNext(IHandler handler)
        {
            _next = handler;
            return handler;
        }
    }

    class PasswordChecker : RegistrationHandler // Concrete handler
    {
        public override void Handle(string request)
        {
            if (request == "Check password")
                Console.WriteLine("Password checker: Password checked");
            else
                base.Handle(request);
        }
    }

    class DatabaseWriter : RegistrationHandler // Concrete handler
    {
        public override void Handle(string request)
        {
            if (request == "Save to database")
                Console.WriteLine("Database writer: Data saved to database");
            else
                base.Handle(request);
        }
    }

    class Verifier : RegistrationHandler // Concrete handler
    {
        public override void Handle(string request)
        {
            if (request == "Verify")
                Console.WriteLine("Verifier: User verified");
            else
                base.Handle(request);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RegistrationHandler passwordChecker = new PasswordChecker();
            RegistrationHandler databaseWriter = new DatabaseWriter();
            RegistrationHandler verifier = new Verifier();

            passwordChecker.SetNext(databaseWriter).SetNext(verifier);
            Console.WriteLine("Password checker > Database writer > Verifier");

            Console.WriteLine("Check password");
            passwordChecker.Handle("Check password");

            Console.WriteLine("Verify");
            passwordChecker.Handle("Verify");

            Console.WriteLine("Make coffee");
            passwordChecker.Handle("Make coffee");

            Console.WriteLine("Save to database");
            passwordChecker.Handle("Save to database");

            Console.ReadLine();
        }
    }
}
