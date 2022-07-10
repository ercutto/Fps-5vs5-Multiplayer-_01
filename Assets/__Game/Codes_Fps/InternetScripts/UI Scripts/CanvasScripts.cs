using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CanvasScripts : MonoBehaviourPunCallbacks
{
    //Objects to set active or false
    [SerializeField]
    private GameObject createRoomCanvas;
    [SerializeField]
    private GameObject roomListingMenu;
    [SerializeField]
    private GameObject currentRoomCanvas;
    [SerializeField]
    private GameObject CustomizeButton;
    [SerializeField]
    private GameObject playerListing;
    [SerializeField]
    private GameObject leaveRoomMenu;
    [SerializeField]
    private GameObject Customize;
    public int SetMaxPlayer = 6;
    //roomListing
    public RoomInfo RoomInfo { get; private set; }
    [SerializeField]
    private TextMeshProUGUI roomText;
    [SerializeField]
    private Transform content;//Instantiateing room name into scrollview content!
    [SerializeField]
    private GameObject roomNamebox;

    //Variables
    [SerializeField]
    private Text roomName;
    #region Room Listing Functions
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        roomText.text = RoomInfo.MaxPlayers + " P- " + roomInfo;
    }
    public void OnClick_JoinToRoom()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
    public override void OnJoinedRoom()
    {
        currentRoomCanvas.SetActive(true);
        content.DestroyChilderen();
    }
    #endregion
    #region Creating room
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
    //We may add random room options later on!
    #endregion
   
}
