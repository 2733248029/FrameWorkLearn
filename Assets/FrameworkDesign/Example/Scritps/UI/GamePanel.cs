using System;
using System.Collections;
using System.Collections.Generic;
using CounterAPP;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GamePanel : MonoBehaviour,IController
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
            mGameModel.Score.RegisterOnvalueChanged(OnScoreValueChanged);
            mGameModel.Gold.RegisterOnvalueChanged(OnGoldValueChanged);
            mGameModel.Life.RegisterOnvalueChanged(OnLifeValueChanged);
            OnScoreValueChanged(mGameModel.Score.Value);
            OnGoldValueChanged(mGameModel.Gold.Value);
            OnLifeValueChanged(mGameModel.Life.Value);
            transform.Find("ScoreText").GetComponent<Text>().text = "分数:" + mGameModel.Score.Value;
        }
        private void OnScoreValueChanged(int score)
        {
            transform.Find("ScoreText").GetComponent<Text>().text = "分数:" + score;
        }
        private void OnLifeValueChanged(int life)
        {
            transform.Find("LifeText").GetComponent<Text>().text = "生命:" + life;
        }

        private void OnGoldValueChanged(int gold)
        {
            transform.Find("GoldText").GetComponent<Text>().text = "金币" + gold;
        }
        private void OnDestroy()
        {
            mGameModel.Score.UnRegisterOnvalueChanged(OnScoreValueChanged);
            mGameModel.Gold.UnRegisterOnvalueChanged(OnGoldValueChanged);
            mGameModel.Life.UnRegisterOnvalueChanged(OnLifeValueChanged);
            mGameModel = null;
            mCountDownSystem = null;
        }
        // Update is called once per frame
        void Update()
        {
            if(Time.frameCount%20==0)
            {
                transform.Find("CountDownText").GetComponent<Text>().text =
                    mCountDownSystem.CurrentRemainSeconds + "s";
                mCountDownSystem.Update();
            }
        }
    }
}

