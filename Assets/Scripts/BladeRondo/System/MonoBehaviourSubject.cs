using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BladeRondo.System
{
    public abstract class MonoBehaviourSubject<T> : MonoBehaviour
    {
        private List<IObserver<T>> _observers;

        public void AddObserver(IObserver<T> observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver<T> observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(T pushData)
        {
            foreach (var observer in _observers)
            {
                observer.ReceiveNotify(pushData);
            }
        }
    }
}