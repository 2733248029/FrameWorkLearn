using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public class Game : MonoBehaviour
    {
        private void Awake()
        {
            GameStartEvent.Register(OnGameStart);
            
        }

        private void OnGameStart()
        {
           transform.Find("Enemies").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            GameStartEvent.unRegister(OnGameStart);

        }

    }

}
