
namespace FrameworkDesign.Example
{
    public class BuyLifeCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gamemodel = this.GetModel<IGameModel>();
            gamemodel.Gold.Value--;
            gamemodel.Life.Value++;
        }


    }
}

