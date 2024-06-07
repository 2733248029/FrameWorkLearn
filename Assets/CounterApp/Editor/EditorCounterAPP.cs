using System.Collections;
using System.Collections.Generic;
using FrameworkDesign;
using UnityEditor;
using UnityEngine;
namespace CounterAPP.Editor
{
    public class EditorCounterAPP : EditorWindow,IController
    {
        [MenuItem("EditorConterAPP/Open")]
        static void Open()
        {
            
            CounterApp.OnRegisterPatch += app =>
            {
                app.RegisterUtility<IStorage>(new EditorPrefsStorage());
            };
            var window =  GetWindow<EditorCounterAPP>();
            window.position = new Rect(100, 100, 400, 600);
            window.titleContent = new GUIContent(nameof(EditorCounterAPP));
            window.Show();

        }

         IArchitecture IBelongToArchitecture. GetArchitecture()
        {
            return CounterApp.Interface;
        }

        private void OnGUI()
        {
            if (GUILayout.Button("+"))
            {
                this.SendCommand<AddCountCommand>();
              
            }
           GUILayout.Label(CounterApp.Get<ICounterModel>().Count.Value.ToString());
            if (GUILayout.Button("-"))
            {
                this.SendCommand<SubCountCommand>();
            }
        }
    }
}

