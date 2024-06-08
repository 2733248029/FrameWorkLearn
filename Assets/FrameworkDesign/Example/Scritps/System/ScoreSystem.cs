using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public interface IScoreSystem:ISystem
    {

    }
    public class ScoreSystem :AbstractSystem,IScoreSystem
    {
        protected override void OnInit()
        {
            var gameModel = this.GetModel<IGameModel>();
            this.RegisterEvent<GamePassEvent>(e =>
            {
                var countDwonSystem = this.GetSystem<ICountDownSystem>();
                var timeScore = countDwonSystem.CurrentRemainSeconds * 10;
                gameModel.Score.Value += timeScore;

                if (gameModel.Score.Value> gameModel.BestScore.Value)
                {
                    Debug.Log("新纪录");
                    Debug.Log("Score"+ gameModel.Score.Value);
                    Debug.Log("BestScore" + gameModel.BestScore.Value);
                    gameModel.BestScore.Value = gameModel.Score.Value;
                }
            });
            this.RegisterEvent<OnEnemyKillEvent>(e =>
            {
                gameModel.Score.Value += 10;
                Debug.Log("得分+10");
                Debug.Log("当前分数" + gameModel.Score.Value);
            });
            this.RegisterEvent<OnMissEvent>(e =>
            {
                gameModel.Score.Value -= 5;
                Debug.Log("得分-5");
                Debug.Log("当前分数" + gameModel.Score.Value);
            });
        }
    }
}

