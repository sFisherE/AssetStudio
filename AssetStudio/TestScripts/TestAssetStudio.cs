using UnityEngine;
using System.Collections;

class TestAssetStudio : MonoBehaviour
{
    private void Start()
    {
        AssetStudio.AssetsManager assetsManager = new AssetStudio.AssetsManager();
        assetsManager.LoadFolder("files");
    }
}
