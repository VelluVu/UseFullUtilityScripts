using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    public static string version = "0.1";
    public string userName; 

    private void Start ( )
    {
        //PhotonNetwork.ConnectUsingSettings ( version );

        //userName = "User" + Random.Range ( 1000, 9999 );
        //PhotonNetwork.player.NickName = userName;
    }

    private void OnGUI ( )
    {
        //GUILayout.Label ( PhotonNetwork.connectionStateDetailed.ToString ( ) );
    }

    private void OnConnectedToMaster()
    {
        Debug.Log ( "Connected To Master" );
    }

    private void OnJoinedLobby()
    {
        Debug.Log ( "Joined Lobby" );
    }

    private void OnJoinedRoom()
    {
        //Debug.Log ( "Joined Room: " + PhotonNetwork.room.Name);
    }

    
   

}
