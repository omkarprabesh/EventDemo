using System;

namespace EventSample
{
    public class EventDemo
    {
        public static void Main()
        {
            Listener1 l1 = new Listener1();


            EventClass a1 = new EventClass();
            a1.eventFired("Here we go!");


            a1.DemoEvent += l1.listener1Message;
           

        }
        public class BName : EventArgs
        {
            public string EventInfo { get; set; }
            public BName(string eInfo)
            {
                EventInfo = eInfo;
            }
        }

        public delegate void SomeEventHandler(object source, BName b);



        public class EventClass
        {

            public event SomeEventHandler DemoEvent;

            public void eventFired(string x)
            {

                if (DemoEvent != null)
                {
                    DemoEvent(this, new BName(x));
                }
            }
        }
        public class Listener1
        {
            public void listener1Message(object sender, BName b)
            {
                Console.WriteLine($"Event was fired with {b.EventInfo}");
            }
        }
    }
}
