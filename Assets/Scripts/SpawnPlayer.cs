using Photon.Pun;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;
    [SerializeField] private float x1;
    [SerializeField] private float y1;
    [SerializeField] private float x2;
    [SerializeField] private float y2;

    private void Start()
    {
        if (PhotonNetwork.CountOfPlayersInRooms == 0)
        {
            Vector2 position = new Vector2(x1, y1);
            PhotonNetwork.Instantiate(playerOne.name, position, Quaternion.identity);
        }

        else if(PhotonNetwork.CountOfPlayersInRooms == 1)
        {
            Vector2 position = new Vector2(x2, y2);
            PhotonNetwork.Instantiate(playerTwo.name, position, Quaternion.identity);
        }
    }
}
