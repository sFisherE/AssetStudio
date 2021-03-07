using System;
using UnityEngine;

class HelpBehaviour : MonoBehaviour
{
    public bool FindAllObjects = false;

    public string m_ClassName;
    [ContextMenu("FindClass")]
    public void Run2()
    {
        GameObject find = null;
        if (FindAllObjects)
        {
            GameObject[] gos = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var item in gos)
            {
                find = FindGameObjectByClassName(item.transform, m_ClassName);
                if (find != null)
                    break;
            }
        }
        else
        {
            find = FindGameObjectByClassName(this.transform, m_ClassName);
        }

        if (find != null)
        {
            Debug.Log(GetGameObjectPath(find.transform));
        }
        else
        {
            Debug.Log("null");
        }
    }
    public long m_PathID;
    [ContextMenu("Find")]
    public void Run()
    {
        GameObject find = null;
        if (FindAllObjects)
        {
            GameObject[] gos = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var item in gos)
            {
                find = FindGameObjectByPathID(item.transform, m_PathID);
                if (find != null)
                    break;
            }
        }
        else
        {
            find = FindGameObjectByPathID(this.transform, m_PathID);
        }
        if (find != null)
        {
            Debug.Log(GetGameObjectPath(find.transform));
        }
        else
        {
            Debug.Log("null");
        }
    }

    string GetGameObjectPath(Transform tf)
    {
        string ret = tf.name;
        var parent = tf.parent;
        while (parent != null)
        {
            ret = parent.name + "/" + ret;
            parent = parent.parent;
        }

        return ret;
    }

    GameObject FindGameObjectByClassName(Transform tf, string name)
    {

        var cmps = tf.GetComponents<DumpedBehaviour>();
        foreach (var c in cmps)
        {
            if (c.m_ClassName == name)
            {
                return c.gameObject;
            }
        }
        for (int i = 0; i < tf.childCount; i++)
        {
            var child = tf.GetChild(i);
            var find = FindGameObjectByClassName(child, name);
            if (find != null) return find;
        }

        return null;
    }

    GameObject FindGameObjectByPathID(Transform tf, long id)
    {
        var cmp = tf.GetComponent<DumpedGameObject>();
        if (cmp != null)
        {
            if (cmp.m_PathID == m_PathID)
            {
                return tf.gameObject;
            }
        }
        var cmps = tf.GetComponents<DumpedBehaviour>();
        foreach (var c in cmps)
        {
            if (c.m_PathID == id)
            {
                return c.gameObject;
            }
        }
        for (int i = 0; i < tf.childCount; i++)
        {
            var child = tf.GetChild(i);
            var find = FindGameObjectByPathID(child, id);
            if (find != null) return find;
        }

        return null;
    }

}
