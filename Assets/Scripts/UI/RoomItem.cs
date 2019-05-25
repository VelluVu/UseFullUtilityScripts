using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{

    Button button;
    TextMeshProUGUI roomText;

    private void Awake ( )
    {
        button = GetComponent<Button> ( );
        roomText = GetComponentInChildren<TextMeshProUGUI> ( );
        button.onClick.AddListener ( ( ) => JoinRoom ( ) );
    }

    /// <summary>
    /// Set RoomName
    /// </summary>
    /// <param name="roomName"> pass PhotonNetwork CreatedRoomName</param>
    public void SetRoomText(string roomName)
    {
        roomText.text = roomName;
    }

    void JoinRoom ( )
    {
        //PhotonNetwork.JoinRoom ( roomText.text );
    }

    private void OnDestroy ( )
    {
        button.onClick.RemoveAllListeners ( );
    }

}
