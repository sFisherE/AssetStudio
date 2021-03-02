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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
