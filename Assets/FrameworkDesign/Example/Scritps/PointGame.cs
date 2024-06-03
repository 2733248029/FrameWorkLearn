using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public class PointGame : Architecture<PointGame>
    {
        protected override void Init()
        {
            Register<IGameModel>(new GameModel());
        }
    }
}

