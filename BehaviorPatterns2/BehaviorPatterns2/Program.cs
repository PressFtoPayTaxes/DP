using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    interface IListener // Observer
    {
        void Listen(RadioStation radioStation);
    }

    class RadioStation // Publisher
    {
        private List<IListener> _listeners = new List<IListener>();
        public string PlayingRecord { get; private set; } = "Red Hot Chili Peppers - Hump de Bump";

        public void ConnectListener(IListener listener) => _listeners.Add(listener);

        public void DisconnectListener(IListener listener) => _listeners.Remove(listener);

        public void SetNewRecord(string record)
        {
            PlayingRecord = record;
            NotifyListeners();
        }

        private void NotifyListeners()
        {
            foreach (var listener in _listeners)
            {
                listener.Listen(this);
            }
        }
    }

    class RadioListener : IListener // ConcreteObserver
    {
        public void Listen(RadioStation radioStation)
        {
            Console.WriteLine($"RadioListener: Listening \"{radioStation.PlayingRecord}\"");
        }
    }

    class TelephoneListener : IListener // ConcreteObserver
    {
        public void Listen(RadioStation radioStation)
        {
            Console.WriteLine($"TelephoneListener: Listening \"{radioStation.PlayingRecord}\"");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RadioListener radioListener = new RadioListener();
            TelephoneListener telephoneListener = new TelephoneListener();

            RadioStation station = new RadioStation();
            station.ConnectListener(radioListener);
            station.ConnectListener(telephoneListener);

            Console.WriteLine("Setting new record...");
            station.SetNewRecord("Queen - Another One Bites The Dust");
        }
    }
}
