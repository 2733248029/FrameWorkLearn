using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public class InterfaceStructExample : MonoBehaviour
    {
        public interface ICustomScript
        {
            void Start();
            void Update();
            void Destroy();
        }
        public abstract class CustomScript : ICustomScript
        {
             void ICustomScript.Destroy()
            {
                OnDestroy();
            }
            
             void ICustomScript.Start()
            {
                OnStart();
            }
            
             void ICustomScript.Update()
            {
                OnUpdate();
            }
            protected abstract void OnStart();
            protected abstract void OnUpdate();
            protected abstract void OnDestroy();
        }
        public class MyScript : CustomScript
        {
            protected override void OnDestroy()
            {
                Debug.Log("Destroy");
            }

            protected override void OnStart()
            {
                Debug.Log("Start");
            }

            protected override void OnUpdate()
            {
                Debug.Log("Update");
            }
        }
        private void Start()
        {
            
            ICustomScript myScript = new MyScript();
            myScript.Start();
            myScript.Update();
            myScript.Destroy();
        }
    }

}

