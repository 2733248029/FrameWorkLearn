using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
namespace FrameworkDesign
{
    public interface IArchitecture
    {
        void RegisterSystem<T>(T system) where T : ISystem;
        void RegisterModel<T>(T model) where T : IModel;
        void RegisterUtility<T>(T utility) where T:IUtility;
        T GetUtility<T>() where T : class,IUtility;
        T GetModel<T>() where T : class,IModel;
        T GetSystem<T>() where T : class, ISystem;
        void SendCommand<T>() where T : ICommand,new();
        void SendCommand<T>(T command) where T : ICommand;

        void SendEvent<T>() where T: new ();
        void SendEvent<T>(T e) ;
        IUnRegister RegisterEvent<T>(Action<T> onEvent);
        void UnRegisterEvent<T>(Action<T> onEvent);
    }
    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        private bool mInited = false;
        private List<IModel> mModels = new List<IModel>();
        private List<ISystem> mSystems = new List<ISystem>();
        private static T mArchitecture;
        public static Action<T> OnRegisterPatch = architecture => { };  
        private IOCContainer mContainer = new IOCContainer();
        public static IArchitecture Interface
        {
            get
            {
                if(mArchitecture == null) 
                {
                    MakeSureArchitecture();
                }
                return mArchitecture;
            }
        }
        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();
                OnRegisterPatch?.Invoke(mArchitecture);
                foreach (var architectureModel in mArchitecture.mModels)
                {
                    architectureModel.Init();
                }
                mArchitecture.mModels.Clear();
                
                foreach (var architectureSystem in mArchitecture.mSystems)
                {
                    architectureSystem.Init();
                }
                mArchitecture.mSystems.Clear();
                mArchitecture.mInited = true;
            }

        }
        protected abstract void Init();

        public void RegisterModel<T>(T model) where T : IModel
        {
            model.SetArchitecture(this) ;
            mContainer.Register<T>(model);
            if(!mInited)
            {
                mModels.Add(model);
            }
            else
            {
                model.Init();
            }
        }
        public void RegisterSystem<T>(T system) where T : ISystem
        {
            system.SetArchitecture(this);
            mContainer.Register<T>(system);
            mContainer.Register<T>(system);
            if (!mInited)
            {
                mSystems.Add(system);
            }
            else
            {
                system.Init();
            }
        }
        public T GetUtility<T>() where T : class, IUtility
        {
            return mContainer.Get<T>();
        }

        public void RegisterUtility<T>(T utility) where T : IUtility
        {
            mContainer.Register<T>(utility);
        }

        public T GetModel<T>() where T : class, IModel
        {
            return mContainer.Get<T>();
        }

        public void SendCommand<T>() where T : ICommand, new()
        {
            var command = new T();
            command.SetArchitecture(this);
            command.Execute();
    
        }

        public void SendCommand<T>(T command) where T : ICommand
        {
            command.SetArchitecture(this);
            command.Execute();
      
        }

        public T GetSystem<T>() where T : class, ISystem
        {
            return mContainer.Get<T>();
        }
        ITypeEventSystem mTypeEventSystem = new TypeEventSystem();
        public void SendEvent<T>() where T : new()
        {
            mTypeEventSystem.Send<T>();
        }

        public void SendEvent<T>(T e)
        {
            mTypeEventSystem.Send<T>(e);
        }

        public IUnRegister RegisterEvent<T>(Action<T> onEvent)
        {
           return  mTypeEventSystem.Register<T>(onEvent);
        }

        public void UnRegisterEvent<T>(Action<T> onEvent)
        {
            mTypeEventSystem.Unregister<T>(onEvent);
        }
    }
}

