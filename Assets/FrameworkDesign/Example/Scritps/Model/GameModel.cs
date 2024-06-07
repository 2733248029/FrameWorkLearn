using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public interface IGameModel:IModel
    {
        BindableProperty<int> KillCount { get; }
        BindableProperty<int> Gold { get; }
        BindableProperty<int> Score { get; }
        BindableProperty<int> BestScore { get; }
    }
    public class GameModel:AbstractModel,IGameModel
{
        
       
        public BindableProperty<int> KillCount { get; } = new BindableProperty<int>() { Value = 0 };
        public BindableProperty<int> Gold { get; } = new BindableProperty<int>() { Value = 0 };
        public BindableProperty<int> Score { get; } = new BindableProperty<int>() { Value = 0 };
        public BindableProperty<int> BestScore { get; } = new BindableProperty<int>() { Value = 0 };

        protected override void OnInit()
        {
           
        }

        // Start is called before the first frame update

    }
}

