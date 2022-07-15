using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor;

[CreateAssetMenu(menuName ="Singletons/MasterManager")]

public class MasterManager : ScriptableObjectSingleton<MasterManager>
{
    [SerializeField]
    private GameSettings _gameSettings;
    public static GameSettings GameSettings { get { return Instance._gameSettings; } }
    [SerializeField]
    private List<NetworkPrefab> _networkedPrefabs = new List<NetworkPrefab>();

    public static Cards card = null;
    public static GunsStat gunStat = null;
    public static int nextPlayersTeam;

    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, Quaternion rotatiton)
    {
        foreach (NetworkPrefab networkPrefab in Instance._networkedPrefabs)
        {
            if (networkPrefab.prefab == obj)
            {
                if (networkPrefab._path != string.Empty)
                {
                    GameObject result = PhotonNetwork.Instantiate(networkPrefab._path, position, rotatiton);
                    return result;
                }
                else
                {
                    Debug.LogError("Path is empty for gameObject name: " + networkPrefab.prefab);
                    return null;
                }

            }
        }
        return null;
    }

    public static void Updateteam()
    {
        if (nextPlayersTeam == 1)
        {
            nextPlayersTeam = 2;
        }
        else
        {
            nextPlayersTeam = 1;
        }
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void PopulateNetrworkPrefabs()
    {
#if UNITY_EDITOR
        Instance._networkedPrefabs.Clear();
        GameObject[] results = Resources.LoadAll<GameObject>("");
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].GetComponent<PhotonView>()!=null)
            {
                string path = AssetDatabase.GetAssetPath(results[i]);
                Instance._networkedPrefabs.Add(new NetworkPrefab(results[i], path));
            }
        }
#endif
    }

}
