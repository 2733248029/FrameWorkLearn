using System.Collections;
using System.Collections.Generic;
using FrameworkDesign;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public class ErrorArea : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }
        private void OnMouseDown()
        {
            Debug.Log("�����");
            //Destroy(gameObject);
            this.SendCommand<MissCommand>();
        }

    }
}

