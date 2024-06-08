using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign
{
    public class BindablePropertyUnRegister<T> : IUnRegister where T : IEquatable<T>
    {
        public BindableProperty<T> BindableProperty { get; set; }
        public Action<T> OnValueChanged { get; set; }
        public void Unregister()
        {
            BindableProperty.UnRegisterOnvalueChanged(OnValueChanged);
            BindableProperty = null;
            OnValueChanged = null;
        }
    }
    public class BindableProperty<T> where T : IEquatable<T>
    {
        private T mValue = default(T);
        private Action<T> mOnValueChanged = v => { };
        public IUnRegister RegisterOnvalueChanged(Action<T> onValueChanged)
        {
            mOnValueChanged += onValueChanged;
            return new BindablePropertyUnRegister<T>()
            {
                BindableProperty = this,
                OnValueChanged = onValueChanged
            };
        }
        public void UnRegisterOnvalueChanged(Action<T> onValueChanged)
        {
            mOnValueChanged -= onValueChanged;

        }
        public T Value
        {
            get => mValue;
            set
            {
                if (!value.Equals(mValue))
                {
                    mValue = value;
                    mOnValueChanged?.Invoke(mValue);
                }
            }
        }
    }
}

