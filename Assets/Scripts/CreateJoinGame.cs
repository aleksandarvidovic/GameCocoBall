using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class CreateJoinGame : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField gameName;

    public void CreateGame()
    {
        SoundManager.PlaySound("click");
        PhotonNetwork.CreateRoom(gameName.text);
    }

    public void JoinGame()
    {
        SoundManager.PlaySound("click");
        PhotonNetwork.JoinRoom(gameName.text);
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CountOfPlayersInRooms > 1)
            PhotonNetwork.Disconnect();
        else
            PhotonNetwork.LoadLevel("TwoPlayers");
    }
}
