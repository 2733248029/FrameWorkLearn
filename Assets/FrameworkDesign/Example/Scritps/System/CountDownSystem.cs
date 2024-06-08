using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public interface ICountDownSystem:ISystem
    {
        int CurrentRemainSeconds { get; }
        void Update();
    }
    public class CountDownSystem : AbstractSystem, ICountDownSystem
    {
        private DateTime mGameStartTime { get; set; }
        private bool mStarted = false;

        public int CurrentRemainSeconds => 10 - (int)(DateTime.Now - mGameStartTime).TotalSeconds;

        public void Update()
        {
            if(mStarted) 
            {
                if(DateTime.Now - mGameStartTime > TimeSpan.FromSeconds(10) )
                {
                    this.SendEvent<OnCountDownEvent>();
                    mStarted = false;
                }
            }
        }

        protected override void OnInit()
        {
            this.RegisterEvent<GameStartEvent>((e) => 
            {
                mStarted = true;
                mGameStartTime = DateTime.Now;
            });
            this.RegisterEvent<GamePassEvent>((e) =>
            {
                mStarted = false;
            });
        }
    }
}

