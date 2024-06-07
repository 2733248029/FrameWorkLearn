using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public struct EventA
    {

    }
    public struct EventB
    {
        public int ParamB;
    }
    public interface IEeventGroup
    {

    }
    public struct EventC:IEeventGroup
    {

    }
    public struct EventD: IEeventGroup
    {

    }
    
    public class TypeEventSystemExample : MonoBehaviour
    {
        private TypeEventSystem mTypeEventSystem = new TypeEventSystem();
        // Start is called before the first frame update
        void Start()
        {
            mTypeEventSystem.Register<EventA>(OnEvent);
            mTypeEventSystem.Register<EventB>(b => 
            {
                Debug.Log("OnEventB"+ b.ParamB);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            mTypeEventSystem.Register<IEeventGroup>(e => 
            {
                Debug.Log(e.GetType());
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }
        private void OnEvent(EventA obj)
        {
            Debug.Log("OnEventA");
        }
        private void OnDestroy()
        {
            mTypeEventSystem.Unregister<EventA>(OnEvent);
            mTypeEventSystem = null;
        }
        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                mTypeEventSystem.Send<EventA>();
            }
            if (Input.GetMouseButtonDown(1))
            {
                mTypeEventSystem.Send(new EventB() { ParamB = 123});
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                mTypeEventSystem.Send<IEeventGroup>(new EventC());
                mTypeEventSystem.Send<IEeventGroup>(new EventD());
            }
        }
    }
}

