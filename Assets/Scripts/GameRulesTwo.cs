using Photon.Pun;
using UnityEngine;

public class GameRulesTwo : MonoBehaviour
{
    [SerializeField] private float centerX;
    [SerializeField] private float outPlayer;
    [SerializeField] private float outPlayer2;

    private Rigidbody2D rb;
    private float serveX = -5.5f;
    private float serveY = 4.5f;
    private bool ballOnSand;
    public static int playerPoints;
    public static int player2Points;
    private int maxPoints = 25;
    private int lastTouch;
    private bool ballInNet;
    public static int playerPointsEnd;
    public static int player2PointsEnd;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(playerPoints >= maxPoints || player2Points >= maxPoints)
            GameOver();
        
        if (ballOnSand)
        {
            ballOnSand = false;
            
            if (rb.position.x < centerX)
            {
                if (rb.position.x < outPlayer)
                {
                    if (lastTouch == 1)
                        Player2GetPoint();
                    else
                        PlayerGetPoint();
                }
                else
                    Player2GetPoint();
            }
            else
            {
                if (rb.position.x > outPlayer2)
                {
                    if (lastTouch == 1)
                        Player2GetPoint();
                    else
                        PlayerGetPoint();
                }
                else
                    PlayerGetPoint();
            }

            ServeBall();
        }

        if (ballInNet)
        {
            ballInNet = false;
            
            if (rb.position.x < centerX)
                Player2GetPoint();
            else
                PlayerGetPoint();
            
            ServeBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Background background = other.gameObject.GetComponent<Background>();

        if (background != null)
            ballOnSand = true;

        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            SoundManager.PlaySound("punch");
            lastTouch = 1;
        }

        PlayerTwo player2 = other.gameObject.GetComponent<PlayerTwo>();

        if (player2 != null)
        {
            SoundManager.PlaySound("punch");
            lastTouch = 2;
        }

        Net net = other.gameObject.GetComponent<Net>();

        if (net != null)
        {
            if (other.contacts[0].normal.y <= 0.5)
                ballInNet = true;
        }
    }

    private void ServeBall()
    {
        rb.velocity = new Vector2(0, 0);
        rb.transform.SetPositionAndRotation(new Vector3(serveX, serveY), Quaternion.identity);
    }

    private void GameOver()
    {
        playerPointsEnd = playerPoints;
        player2PointsEnd = player2Points;
        PhotonNetwork.LoadLevel("GameOverTwoPlayers");
    }

    private void PlayerGetPoint()
    {
        playerPoints++;
        serveX = 5.5f;
    }
    
    private void Player2GetPoint()
    {
        player2Points++;
        serveX = -5.5f;
    }
}