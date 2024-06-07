using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public class Game : MonoBehaviour,IController
    {
        private void Awake()
        {
            this.RegisterEvent<GameStartEvent>(OnGameStart);
            
        }

        private void OnGameStart(GameStartEvent e)
        {
           transform.Find("Enemies").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<GameStartEvent>(OnGameStart);

        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }
    }

}
