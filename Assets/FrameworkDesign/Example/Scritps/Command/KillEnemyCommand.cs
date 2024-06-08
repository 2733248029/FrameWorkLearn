
namespace FrameworkDesign.Example
{
    public class KillEnemyCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gamemodel = this.GetModel<IGameModel>();
            gamemodel.KillCount.Value++;
            if(UnityEngine.Random.Range(0,10)<3)
            {
                gamemodel.Gold.Value += UnityEngine.Random.Range(1, 3);
            }
            this.SendEvent<OnEnemyKillEvent>();
            if (gamemodel.KillCount.Value == 10 )
            {
                this.SendEvent<GamePassEvent>();
            }
        }


    }
}

