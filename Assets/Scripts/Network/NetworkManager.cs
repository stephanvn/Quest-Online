using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour
{

    SpawnSpot[] spawnSpots;

    void Start()
    {
        spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();
        Connect();
    }

    void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("RPGenius v001");
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");

        PhotonPlayer[] otherList = PhotonNetwork.otherPlayers;
        SpawnMyPlayer(otherList.Length);
    }

    void SpawnMyPlayer(int players)
    {             
        SpawnSpot mySpawnSpot = spawnSpots[players];
        PhotonNetwork.Instantiate("MainPlayer", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
    }
}
