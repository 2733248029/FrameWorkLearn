using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public class IOCExample : MonoBehaviour
    {
        private void Start()
        {
            var contaniner = new IOCContainer();
            contaniner.Register<IBluetoothManager>(new BluetoothManager());
            var bluetoothManager  = contaniner.Get<IBluetoothManager>();
            bluetoothManager.Connect();
        }
        public interface IBluetoothManager
        {
            void Connect();
        }
        public class BluetoothManager: IBluetoothManager
        {
            public void Connect()
            {
                Debug.Log("蓝牙连接成功");
            }
        }

    }
}

