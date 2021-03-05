using UnityEngine;
using UnityEditor;
using System.Collections;

class TestAssetStudio : MonoBehaviour
{
    public string projectName = "";
    public string folderName = "files";
    public string filePath = "";
    public bool dumpRes = false;
        AssetStudio.AssetsManager assetsManager = new AssetStudio.AssetsManager();

    [ContextMenu("Load")]
    private void Load()
    {
        ProjectInfo.dumpRes = dumpRes;
        if (!string.IsNullOrEmpty(folderName))
        {
            assetsManager.LoadFolder(folderName);
        }
        else
        {
            System.GC.Collect();
            Resources.UnloadUnusedAssets();

            ProjectInfo.projectName = projectName;
            string path = filePath.ToLower().Replace("\\", "/");
            int index= path.LastIndexOf('/');
            ProjectInfo.fileName = path.Substring(index);
            Debug.Log(ProjectInfo.dumpFolder);
            assetsManager.LoadFiles(filePath);
        }
        AssetDatabase.Refresh();
        
    }
}
