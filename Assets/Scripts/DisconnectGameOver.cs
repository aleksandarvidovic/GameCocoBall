using Photon.Pun;
using UnityEngine;

public class DisconnectGameOver : MonoBehaviour
{
    private void Start()
    {
        PhotonNetwork.Disconnect();
    }
}
