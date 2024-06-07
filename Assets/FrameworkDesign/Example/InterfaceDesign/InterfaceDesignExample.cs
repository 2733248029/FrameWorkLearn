using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public class InterfaceDesignExample : MonoBehaviour, ICanSayHello
    {
        public void SayHello()
        {
            Debug.Log("SayHello");
        }

         void ICanSayHello.SayOhter()
        {
            Debug.Log("SayOther");
        }
        private void Start()
        {
            this.SayHello();
            (this as ICanSayHello).SayOhter();
        }
    }
    public interface ICanSayHello
    {
        void SayHello();
        void SayOhter();
    }
}

