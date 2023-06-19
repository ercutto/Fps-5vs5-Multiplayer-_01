using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class NetConnection : MonoBehaviourPunCallbacks
{

    void Start()
    {
        print("Connecting to Server...");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;//We will change this system afte we finnish game
        PhotonNetwork.GameVersion = MasterManager.GameSettings.gameVersion;//We will use game version after when we make update game 
        //way to change game version is we have to write on game settings and change gameversions last number. this avoids active games collaps.
        PhotonNetwork.ConnectUsingSettings();

    }
    public override void OnConnectedToMaster()
    {
        print("Connected to Server!");
        print("NickName: " + PhotonNetwork.LocalPlayer.NickName);
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected! " + cause.ToString());
    }
   
}


  
