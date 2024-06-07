using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using CounterAPP;
using FrameworkDesign;


public class AddCountCommand : AbstractCommand
{
    protected override void OnExecute()
    {
        this.GetModel<ICounterModel>().Count.Value++;
    }
}
