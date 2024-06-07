using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign
{
    public interface ICanRegisterEvent : IBelongToArchitecture
    {

    }
    public static class CanRegisterEventExtension
    {
        public static IUnRegister RegisterEvent<T>(this ICanRegisterEvent self, Action<T> OnEvent)
        {
           return  self.GetArchitecture().RegisterEvent<T>(OnEvent);
        }
        public static void UnRegisterEvent<T>(this ICanRegisterEvent self, Action<T> OnEvent)
        {
            self.GetArchitecture().UnRegisterEvent<T>(OnEvent);
        }
    }
}


