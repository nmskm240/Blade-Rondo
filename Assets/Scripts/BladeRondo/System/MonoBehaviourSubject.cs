using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace BladeRondo.System
{
    public abstract class MonoBehaviourSubject<T> : MonoBehaviour
    {
        private List<IObserver<T>> _observers;

        private void Awake()
        {
            _observers = new List<IObserver<T>>();
        }

        public void AddObserver(IObserver<T> observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver<T> observer)
        {
            _observers.Remove(observer);
        }

        public bool ContainsObserver(IObserver<T> observer)
        {
            return _observers.Contains(observer);
        }

        public void ClearObservers()
        {
            _observers.Clear();
        }

        [PunRPC]
        protected void NotifyObservers(T pushData)
        {
            foreach (var observer in _observers)
            {
                observer.ReceiveNotify(pushData);
            }
        }
    }
}