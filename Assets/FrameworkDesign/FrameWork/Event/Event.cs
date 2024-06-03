using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign
{
    public class Event<T> where T:Event<T>
    {
        private static Action mOnEventTrigger;
        public static void Register(Action onEvent)
        {
            mOnEventTrigger += onEvent;
        }
        public static void unRegister(Action onEvent)
        {
            mOnEventTrigger -= onEvent;
        }

        public static void Trigger()
        {
            mOnEventTrigger.Invoke();
        }
    }

}
