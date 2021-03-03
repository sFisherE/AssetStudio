using UnityEngine;
using System.Collections;

class TestAssetStudio : MonoBehaviour
{
    public string folderName = "files";
    private void Start()
    {
        AssetStudio.AssetsManager assetsManager = new AssetStudio.AssetsManager();
        assetsManager.LoadFolder(folderName);
    }
}
