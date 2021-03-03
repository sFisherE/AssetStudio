using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{

    public string name;
    public AssetBundle shader;
    public AssetBundle ab;
    // Use this for initialization
    void Start()
    {
        shader= AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/shader.assetbundle");
        string path = Application.streamingAssetsPath+ "/" + name;
        ab = AssetBundle.LoadFromFile(path);

        if (name.Contains(".unity"))
        {
            string levelName = name.Substring(0, name.IndexOf('.'));
            Debug.Log(levelName);
            UnityEngine.Application.LoadLevel(levelName);

            //MonoBehaviour[] cmps = FindObjectsOfType<MonoBehaviour>();
            //foreach(var item in cmps)
            //{
            //    Debug.Log(item.name);
            //}

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
