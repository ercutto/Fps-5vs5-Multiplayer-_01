using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private string _gameVersion = "0.0.0";
    public string gameVersion { get { return _gameVersion; } }
    [SerializeField] private string _nickName = "player ";
    public string nickName { get { int value = Random.Range(0, 999); return _nickName + value.ToString(); } }
}
