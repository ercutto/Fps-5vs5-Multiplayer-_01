using System;
using UnityEngine;
[System.Serializable]
public class NetworkPrefab
{
    public GameObject prefab;
    public string _path;

    public NetworkPrefab(GameObject obj,string path)
    {
        prefab = obj;
        _path = PrefabPathModifier(path);
    }

    private string PrefabPathModifier(string path)
    {
        int extensionLength = System.IO.Path.GetExtension(path).Length;
        int additionalLength = 10;
        int startIndex = path.ToLower().IndexOf("resources");
        if (startIndex == -1)
            return string.Empty;
        else
            return path.Substring(startIndex + additionalLength, path.Length - (additionalLength + startIndex + extensionLength));
    }
}