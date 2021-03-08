using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
class TestAssetStudio : MonoBehaviour
{
    public string projectName = "";
    public string folderName = "";
    public string[] filePath = new string[1];
    public bool dumpRes = false;
    AssetStudio.AssetsManager assetsManager = new AssetStudio.AssetsManager();

    public bool autoLoad = true;
    private void Start()
    {
        if (autoLoad)
            Load();
    }

    public bool m_IsLoadLevel = false;
    public int m_StartLevelIndex = 0;
    public int m_EndLevelIndex = 0;

    [ContextMenu("Load")]
    private void Load()
    {
        ProjectInfo.dumpRes = dumpRes;
        ProjectInfo.projectName = projectName;


        if (string.IsNullOrEmpty(folderName))
        {
            var array = new string[filePath.Length];
            for (int i = 0; i < filePath.Length; i++)
            {
                array[i] = Path.Combine(folderName, filePath[i]);
                Debug.Log("loading:" + array[i]);
            }
            assetsManager.LoadFiles(array);
            AssetDatabase.Refresh();
            return;
        }
        if (m_IsLoadLevel)
        {
            var array = new string[m_EndLevelIndex - m_StartLevelIndex + 1];
            for (int i = m_StartLevelIndex; i <= m_EndLevelIndex; i++)
            {
                array[i - m_StartLevelIndex] = Path.Combine(folderName, "level" + i.ToString());
                Debug.Log("loading:" + array[i - m_StartLevelIndex]);
            }
            assetsManager.LoadFiles(array);

            return;
        }

        if (filePath.Length == 0)
            assetsManager.LoadFolder(folderName);

        AssetDatabase.Refresh();

    }
}
