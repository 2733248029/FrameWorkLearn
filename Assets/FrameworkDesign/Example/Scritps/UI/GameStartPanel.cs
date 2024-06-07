using System.Collections;
using System.Collections.Generic;
using CounterAPP;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GameStartPanel : MonoBehaviour,IController
    {
         IArchitecture IBelongToArchitecture. GetArchitecture()
        {
            return PointGame.Interface;
        }

        // Start is called before the first frame update
        void Start()
        {
            transform.Find("BtnStart").GetComponent<Button>()
                .onClick.AddListener(() => 
                {
                    gameObject.SetActive(false);
                    this.SendCommand<StartGameCommand>();
                });
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

