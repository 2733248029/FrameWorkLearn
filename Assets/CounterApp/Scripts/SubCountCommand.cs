using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using CounterAPP;
using FrameworkDesign;


public struct SubCountCommand : FrameworkDesign.ICommand
{
    public void Execute()
    {
        CounterApp.Get<ICounterModel>().Count.Value--;
    }
}
