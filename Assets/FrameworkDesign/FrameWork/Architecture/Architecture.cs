using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
namespace FrameworkDesign
{
    public interface IArchitecture
    {
        T GetUtility<T>() where T : class;
    }
    public abstract class Architecture<T>: IArchitecture where T : Architecture<T>,new()
    {
        private bool mInited = false;
        private List<IModel> mModels = new List<IModel>();
        private static T mArchitecture;
        private IOCContainer mContainer = new IOCContainer();
        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();
                foreach (var architectureModel in mArchitecture.mModels)
                {
                    architectureModel.Init();
                }
                mArchitecture.mModels.Clear();
                mArchitecture.mInited = true;
            }
        }
        protected abstract void Init();
        public static T Get<T>()where T:class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }
        public void Register<T>(T instance) where T: class
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }
        public void RegisterModel<T>(T model) where T : IModel
        {
            model.Architecture = this;
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
        public T GetUtility<T>() where T : class
        {
            return mContainer.Get<T>();
        }
    }
}

