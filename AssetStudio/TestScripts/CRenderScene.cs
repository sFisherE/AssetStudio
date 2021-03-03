using UnityEngine;
using UnityEditor;
namespace L10.Engine.Scene
{
    public class CRenderScene : MonoBehaviour
    {
        public int MapWidth;
        public int MapHeight;
        public bool Enable_SceneSpotLight;
        public bool Enable_SceneSpotSpecular;
        public bool Enable_SceneSpotDiffuse;
        public Color SceneSpotLightColor;
        public float SceneSpotInnerRadius;
        public float SceneSpotOuterRadius;
        public float SceneSpotLightHeight;


        [ContextMenu("dump")]
        void Test()
        {
            MonoBehaviour[] cmps = FindObjectsOfType<MonoBehaviour>();
            foreach (var item in cmps)
            {
                Debug.Log(item.GetType().ToString()+" "+item.name);

                //obj = new UnityEditor.SerializedObject(item);
               MonoScript script = MonoScript.FromMonoBehaviour(item);

                Debug.Log(AssetDatabase.GetAssetPath(script));


                serializedObject = new UnityEditor.SerializedObject(item);
                SerializedProperty prop = serializedObject.GetIterator();
                if (prop.NextVisible(true))
                {
                    do
                    {
                        if(prop.name== "m_Script")
                        {
                            Debug.Log(prop.objectReferenceValue);
                            if (prop.objectReferenceValue != null)
                            {
                                MonoScript s = prop.objectReferenceValue as MonoScript;
                                Debug.Log(s.name + " " + s.text);
                            }
                            prop.objectReferenceValue = AssetDatabase.LoadAssetAtPath<MonoScript>("Assets/AssetStudio/TestScripts/CRenderScene.cs");
                        }
                        //Debug.Log(prop.name);
                    }
                    while (prop.NextVisible(false));
                }
            }
        }

        public UnityEditor.SerializedObject serializedObject;
    }
}
