using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CanvasScripts : MonoBehaviour
{
    //Objects to set active or false
    [SerializeField]
    private GameObject createRoomCanvas;
    [SerializeField]
    private GameObject roomListingMenu;
    [SerializeField]
    private GameObject currentRoomCanvas;
    [SerializeField]
    private GameObject CostumizeButton;
    [SerializeField]
    private GameObject playerListing;
    [SerializeField]
    private GameObject leaveRoomMenu;
    [SerializeField]
    private GameObject Costumize;
    public int SetMaxPlayer = 6;

    //Variables
    [SerializeField]
    private Text roomName;

    //Buttons
    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        RoomOptions options = new RoomOptions();
        options.BroadcastPropsChangeToAll = true;
        options.MaxPlayers = (byte)SetMaxPlayer;
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, TypedLobby.Default);
    }
    //We may add random roo options later on!

}
