
namespace FrameworkDesign.Example
{
    public struct KillEnemyCommand : ICommand
    {
        public void Execute()
        {
            var gamemodel = PointGame.Get<IGameModel>();
            gamemodel.KillCount.Value++;
            if (gamemodel.KillCount.Value == 10 )
            {
                GamePassEvent.Trigger();
            }
        }


    }
}

