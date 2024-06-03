using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindableProperty<T> where T:IEquatable<T> 
{
    private T mValue = default(T);
    public Action<T> OnValueChanged;
    public T Value {
        get =>  mValue;
        set
        {
            if(!value.Equals(mValue))
            {
                mValue = value;
                OnValueChanged?.Invoke(mValue);
            }
        }
    }
    
}
