using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInputField;
    public TMP_InputField joinInputField;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInputField.text); //also joins the room
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInputField.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
    }
}
