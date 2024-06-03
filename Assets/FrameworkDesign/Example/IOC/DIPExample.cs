#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
namespace FrameworkDesign.Example
{
    public class DIPExample:MonoBehaviour
    {
        private void Start()
        {
            var container = new IOCContainer();
            container.Register<IStorage>(new PlayerPresStorage());
            var storage = container.Get<IStorage>();
            storage.SaveString("name", "‘À–– ±¥Ê¥¢");
            Debug.Log(storage.LoadString("name", ""));
            container.Register<IStorage>(new EditorPrefsStorage());
            storage = container.Get<IStorage>();
            Debug.Log(storage.LoadString("name", ""));
        }
        public interface IStorage
        {
            void SaveString(string key,string value);
            string LoadString(string key,string value);
        }
        public class PlayerPresStorage : IStorage
        {
            public string LoadString(string key, string defaultValue = "" )
            {
               return PlayerPrefs.GetString(key, defaultValue);
            }

            public void SaveString(string key, string value)
            {
                PlayerPrefs.SetString(key, value);
            }
        }
        public class EditorPrefsStorage : IStorage
        {

            public string LoadString(string key, string defaultValue ="")
            {
#if UNITY_EDITOR_64
                return EditorPrefs.GetString(key, defaultValue);
#endif
            }

            public void SaveString(string key, string value)
            {
#if UNITY_EDITOR
                EditorPrefs.SetString(key, value);
#endif
            }
        }
    }
}

