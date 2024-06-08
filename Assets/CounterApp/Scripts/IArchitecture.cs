using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using FrameworkDesign;
using UnityEngine;
namespace CounterAPP
{
    public interface IArchitectureSystem : ISystem
    {

    }
    public class AchievementSystem :AbstractSystem, IArchitectureSystem
    {
        public IArchitecture Architecture { get;set; }
       

        protected override void OnInit()
        {
        var counterModel = this.GetModel<ICounterModel>();
        var previousCount = counterModel.Count.Value;
        counterModel.Count.RegisterOnvalueChanged ( newCount =>
        {

            if (previousCount < 10 && newCount >= 10)
            {
                Debug.Log("�������10�γɾ���");
            }
            else if (previousCount < 20 && newCount >= 20)
            {
                Debug.Log("�������20�γɾ���");
            }
            previousCount = newCount;
        });
        }
    }
}

