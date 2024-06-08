using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public interface IAchievementSystem:ISystem
    {

    }
    public class AchievementSystemItem
    {
        public string Name { get; set; }
        public Func<bool> CheckComplete { get; set; }
        public bool Unlocked { get; set; }
    }
    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        private List<AchievementSystemItem> mItems = new List<AchievementSystemItem>();
        private bool mMissed = false;

        protected override void OnInit()
        {
            this.RegisterEvent<OnMissEvent>(e => 
            {
                mMissed = true;
            });
            this.RegisterEvent<GameStartEvent>(e =>
            {
                mMissed = false;
            });
            mItems.Add(new AchievementSystemItem()
            {
                Name = "百分成就",
                CheckComplete = () =>
                {
                    return this.GetModel<IGameModel>().Score.Value > 100;
                }
            });
            mItems.Add(new AchievementSystemItem()
            {
                Name = "手残",
                CheckComplete = () =>
                {
                    return this.GetModel<IGameModel>().Score.Value < 0;
                }
            });
            mItems.Add(new AchievementSystemItem()
            {
                Name = "零失误成就",
                CheckComplete = () =>
                {
                    return !mMissed;
                }
            });
            mItems.Add(new AchievementSystemItem()
            {
                Name = "全成就",
                CheckComplete = () => mItems.Count(item => item.Unlocked)>=3
            });
            this.RegisterEvent<GamePassEvent>(async e =>
            {
                await Task.Delay(TimeSpan.FromSeconds(0.1));
                foreach(var achievementItem in mItems)
                {
                    if(!achievementItem.Unlocked&& achievementItem.CheckComplete())
                    {
                        achievementItem.Unlocked = true;
                        Debug.Log("解锁成就" + achievementItem.Name); 
                    }
                }
            });
        }
    }
}

