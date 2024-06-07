
namespace FrameworkDesign.Example
{
    public class KillEnemyCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gamemodel = this.GetModel<IGameModel>();
            gamemodel.KillCount.Value++;
            if (gamemodel.KillCount.Value == 10 )
            {
                this.SendEvent<GamePassEvent>();
            }
        }


    }
}

