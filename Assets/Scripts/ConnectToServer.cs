using Photon.Pun;
using UnityEngine;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject loadingText;
    
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        loadingText.SetActive(false);
    }
}
