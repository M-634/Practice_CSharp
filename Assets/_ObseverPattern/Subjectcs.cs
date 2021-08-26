using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DesignPatterns.Observer
{
    // The Subject owns some important state and notifies observers when the state change.
    public class Subject : ISubject
    {
        //List of subscirbers. In real life
        private List<IObserver> m_observers = new List<IObserver>();

        // For the sake of simpicity, The Subject's state, essential to all subscribers, is stored in this variable.
        public int State { get; set; } = 0;

        /// <summary>
        /// The subscription managment methods.
        /// </summary>
        /// <param name="observer"></param>
        public void Attach(IObserver observer)
        {
            m_observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            m_observers.Remove(observer);
        }

        /// <summary>
        /// Trigger an update in each subscriber
        /// </summary>
        public void Notify()
        {
            foreach (var observer in m_observers)
            {
                observer.Update(this);
            }
        }

        /// <summary>
        /// Sample method
        /// </summary>
        public void SomeBusinessLogic()
        {
            State = new Random().Next(0, 10);
            Notify();
        }
    }

    public class ConcreteObServerA : IObserver
    {
        public void Update(ISubject subject)
        {
            throw new NotImplementedException();
        }
    }
    public class ConcreteObServerB : IObserver
    {
        public void Update(ISubject subject)
        {
            throw new NotImplementedException();
        }
    }
}
