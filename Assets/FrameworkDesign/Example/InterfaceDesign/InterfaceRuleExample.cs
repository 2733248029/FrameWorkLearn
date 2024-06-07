using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public class CanDoEverthing
    {
        public void DoSmoething1()
        {
            Debug.Log("DoSmoething1");
        }
        public void DoSmoething2()
        {
            Debug.Log("DoSmoething2");
        }
        public void DoSmoething3()
        {
            Debug.Log("DoSmoething3");
        }
    }
    public interface IHasEveryThing
    {
        CanDoEverthing CanDoEverthing { get; }
    }
    public interface ICanDoSomething1: IHasEveryThing
    {

    }
    public static class ICanDoSomething1Extension
    {
        public static void DoSomething1(this ICanDoSomething1 self)
        {
            self.CanDoEverthing.DoSmoething1();
            
        }
    }

    public interface ICanDoSomething2 : IHasEveryThing
    {

    }
    public static class ICanDoSomething2Extension
    {
        public static void DoSomething2(this ICanDoSomething2 self)
        {
            self.CanDoEverthing.DoSmoething2();

        }
    }
    public interface ICanDoSomething3 : IHasEveryThing
    {

    }
    public static class ICanDoSomething3Extension
    {
        public static void DoSomething3(this ICanDoSomething3 self)
        {
            self.CanDoEverthing.DoSmoething3();

        }
    }
    public class InterfaceRuleExample : MonoBehaviour
    {
        public class OnlyCanDo1 : ICanDoSomething1
        {
             CanDoEverthing IHasEveryThing.CanDoEverthing { get ; } = new CanDoEverthing();
        }
        public class OnlyCanDo23 : ICanDoSomething2, ICanDoSomething3
        {
             CanDoEverthing IHasEveryThing.CanDoEverthing { get; } = new CanDoEverthing();
        }
        private void Start()
        {
            var onlyCanDo1 = new OnlyCanDo1();
            //(onlyCanDo1 as ICanDoSomething1).CanDoEverthing.DoSmoething3();
            onlyCanDo1.DoSomething1();
            var onlyCanDo23 = new OnlyCanDo23();
            onlyCanDo23.DoSomething2();
            onlyCanDo23.DoSomething3();

        }
    }
}

