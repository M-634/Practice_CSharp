using System;

namespace DesignPatterns.Observer
{
    public interface IObservable<T>
    {
        void Subscribe(Action<T> action);        
    }
}
