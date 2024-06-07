using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using static FrameworkDesign.TypeEventSystem;

namespace FrameworkDesign
{
    public interface ITypeEventSystem
    { 
        void Send<T>() where T : new();
        void Send<T>(T e);
        IUnRegister Register<T>(Action<T> onEvent);
        void Unregister<T>(Action<T> onEvent);
    }
    public interface IUnRegister
    {
        void Unregister();
    }
    public struct TypeEventUnRegister<T> : IUnRegister
    {
        public ITypeEventSystem typeEventSystem;
        public Action<T> Onevent;
        public void Unregister()
        {
            typeEventSystem.Unregister<T>(Onevent);
            typeEventSystem = null;
            Onevent = null;
        }
    }
    public class UnRegisterDestroyTrigger:MonoBehaviour
    {
        HashSet<IUnRegister> unRegisters = new HashSet<IUnRegister>();
        public void AddUnRegister(IUnRegister register)
        {
            unRegisters.Add(register);
        }
        private void OnDestroy()
        {
            foreach (var unRegister in unRegisters) 
            {
                unRegister.Unregister();
            }
            unRegisters.Clear();
        }
    }
    public static class UnRegisterExtension
    {
        public static void UnRegisterWhenGameObjectDestroyed(this IUnRegister unRegister,GameObject gameObject)
        {
            var trigger = gameObject.GetComponent<UnRegisterDestroyTrigger>();
            if(!trigger)
            {
                trigger = gameObject.AddComponent<UnRegisterDestroyTrigger>();
            }
            trigger.AddUnRegister(unRegister);
        }
    }
    public class TypeEventSystem : ITypeEventSystem
    {
        Dictionary<Type, IRegistrations> mEventRegistration = new Dictionary<Type, IRegistrations>();
        public interface IRegistrations
        {

        }
        public class Registrations<T>: IRegistrations
        {
            public Action<T> OnEvent = (e) =>
            {

            };
        }
        public IUnRegister Register<T>(Action<T> onEvent)
        {
            var type = typeof(T);
            IRegistrations registrations;
            if(mEventRegistration.TryGetValue(type,out registrations))
            {
               
            
            }
            else
            {
                registrations = new Registrations<T>();
                mEventRegistration.Add(type, registrations);
            }
             (registrations as Registrations<T>).OnEvent += onEvent;
            return new TypeEventUnRegister<T>()
            {
                typeEventSystem = this,
                Onevent = onEvent
            };
        }

        public void Send<T>() where T : new()
        {
            {
                var e = new T();
                Send<T>(e);
            }
        }
        public void Send<T>(T e)
        {
            var type = typeof(T);
            IRegistrations registrations;
            if (mEventRegistration.TryGetValue(type, out registrations))
            {
                (registrations as Registrations<T>).OnEvent?.Invoke(e);
            }
        }

        public void Unregister<T>(Action<T> onEvent)
        {
            var type = typeof(T);
            IRegistrations registrations;
            if (mEventRegistration.TryGetValue(type, out registrations))
            {
                (registrations as Registrations<T>).OnEvent -= onEvent;
            }
        }
    }

}
