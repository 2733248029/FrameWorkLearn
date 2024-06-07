using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign
{
    public interface IController : IBelongToArchitecture,ICanSendCommand,ICanGetModel,ICanGetSystem, ICanRegisterEvent
    {
       
    }
}

