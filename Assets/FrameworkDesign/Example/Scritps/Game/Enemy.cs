using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour,IController
    {
         IArchitecture IBelongToArchitecture. GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void OnMouseDown()
        {
            
            Destroy(gameObject);
            this.SendCommand<KillEnemyCommand>();
            
            
        }
    }
}


