using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace DesignPatterns.Observer
{
    /// <summary>
    /// UniRxのSubjectクラスを参考にしました。
    /// リアクティブプログラミングを実装する簡単なサンプルです。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Subject<T> : IObservable<T>, IObserver<T>
    {
        List<Action<T>> m_observers = new List<Action<T>>();

        public void OnNext(T value)
        {
            foreach (var observer in m_observers)
            {
                observer.Invoke(value);
            }
        }

        public void Subscribe(Action<T> action)
        {
            m_observers.Add(action);
        }
    }
}
