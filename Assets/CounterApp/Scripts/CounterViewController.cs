using System;
using System.Collections;
using System.Collections.Generic;
using CounterAPP;
using FrameworkDesign;
using UnityEngine;
using UnityEngine.UI;

namespace CounterAPP
{
    public class CounterViewController : MonoBehaviour,IController
    {
        private ICounterModel mCounterModel;

       
        private void Start()
        {
            mCounterModel = this.GetModel<ICounterModel>();
            mCounterModel.Count.OnValueChanged += OnCountChanged;
            OnCountChanged(mCounterModel.Count.Value);
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //½»»¥Âß¼­
                this.SendCommand<AddCountCommand>();
              
              
            });
            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                //½»»¥Âß¼­
                this.SendCommand<SubCountCommand>();

            });
            
        }

        private void OnCountChanged(int newCount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
        }



        private void Update()
        {
            
        }
        private void OnDestroy()
        {
            mCounterModel.Count.OnValueChanged -= OnCountChanged;
            mCounterModel = null;
        }

         IArchitecture IBelongToArchitecture. GetArchitecture()
        {
           return  CounterApp.Interface;
        }

    }
}
    public interface ICounterModel:IModel
    {
        BindableProperty<int> Count { get; }
    }
    public  class CounterModel:AbstractModel, ICounterModel
    {

        public  BindableProperty<int> Count { get; } = new BindableProperty<int>()
        {
            Value = 0,
        };
        public IArchitecture Architecture { get; set; } 



    protected override void OnInit()
    {
        
        var storage = this.GetUtility<IStorage>();
        Count.Value = storage.LoadInt("COUNTER_COUNT");
        Count.OnValueChanged += count =>
        {
            storage.SaveInt("COUNTER_COUNT", count);
        };
    }
}


