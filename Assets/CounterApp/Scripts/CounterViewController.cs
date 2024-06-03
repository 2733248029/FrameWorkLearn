using System;
using System.Collections;
using System.Collections.Generic;
using FrameworkDesign;
using UnityEngine;
using UnityEngine.UI;

namespace CounterAPP
{
    public class CounterViewController : MonoBehaviour
    {
        private ICounterModel mCounterModel;
        private void Start()
        {
            mCounterModel = CounterApp.Get<ICounterModel>();
            mCounterModel.Count.OnValueChanged += OnCountChanged;
            OnCountChanged(mCounterModel.Count.Value);
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //½»»¥Âß¼­
                new AddCountCommand().Execute();
              
            });
            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                //½»»¥Âß¼­
                new SubCountCommand().Execute();

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
    }
    public interface ICounterModel:IModel
    {
        BindableProperty<int> Count { get; }
    }
    public  class CounterModel: ICounterModel
    {

        public  BindableProperty<int> Count { get; } = new BindableProperty<int>()
        {
            Value = 0,
        };
        public IArchitecture Architecture { get; set; }

        public void Init()
        {
            var storage = Architecture.GetUtility<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT");
            Count.OnValueChanged += count =>
            {
                storage.SaveInt("COUNTER_COUNT", count);
            };
        }
    }

}
