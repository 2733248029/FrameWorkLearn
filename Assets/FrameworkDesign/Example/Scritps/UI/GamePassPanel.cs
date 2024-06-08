using System;
using System.Collections;
using System.Collections.Generic;
using CounterAPP;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GamePassPanel : MonoBehaviour,IController
    {
        private IGameModel mGameModel;
        private ICountDownSystem mCountDownSystem;
         IArchitecture IBelongToArchitecture. GetArchitecture()
        {
            return PointGame.Interface;
        }

        // Start is called before the first frame update
        void Start()
        {
            mCountDownSystem = this.GetSystem<ICountDownSystem>();
            mGameModel = this.GetModel<IGameModel>();
            transform.Find("BestScoreText").GetComponent<Text>().text = "最高分数:" + mGameModel.BestScore.Value;
            transform.Find("ScoreText").GetComponent<Text>().text = "分数:" + mGameModel.Score.Value;
            transform.Find("CountDownText").GetComponent<Text>().text ="剩余时间" + mCountDownSystem.CurrentRemainSeconds+"s";
        }




        // Update is called once per frame
        void Update()
        {
        }
    }
}

