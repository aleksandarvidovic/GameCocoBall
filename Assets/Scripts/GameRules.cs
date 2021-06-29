using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
    [SerializeField] private float centerX;
    [SerializeField] private float outPlayer;
    [SerializeField] private float outBot;
    [SerializeField] private GameObject loadingObjects;
    [SerializeField] private Slider slider;

    private Rigidbody2D rb;
    private float serveX = -5.5f;
    private float serveY = 4.5f;
    private Player player;
    private Bot bot;
    private bool ballOnSand;
    public static int playerPoints;
    public static int botPoints;
    private int maxPoints = 25;
    private int lastTouch;
    private bool ballInNet;
    public static int playerPointsEnd;
    public static int botPointsEnd;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        bot = FindObjectOfType<Bot>();
    }

    private void FixedUpdate()
    {
        if(playerPoints == maxPoints || botPoints == maxPoints)
            GameOver();
        
        if (ballOnSand)
        {
            ballOnSand = false;
            
            if (rb.position.x < centerX)
            {
                if (rb.position.x < outPlayer)
                {
                    if (lastTouch == 1)
                        BotGetPoint();
                    else
                        PlayerGetPoint();
                }
                else
                    BotGetPoint();
            }
            else
            {
                if (rb.position.x > outBot)
                {
                    if (lastTouch == 1)
                        BotGetPoint();
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
                BotGetPoint();
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

        Bot bot = other.gameObject.GetComponent<Bot>();

        if (bot != null)
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
        player.transform.position = new Vector3(-5, -2.2f);
        bot.transform.position = new Vector3(5, -2.2f);
        rb.velocity = new Vector2(0, 0);
        rb.transform.SetPositionAndRotation(new Vector3(serveX, serveY), Quaternion.identity);
    }

    private void GameOver()
    {
        playerPointsEnd = playerPoints;
        botPointsEnd = botPoints;
        StartCoroutine(LoadASync("GameOverOnePlayer"));
    }

    IEnumerator LoadASync(string scene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);

        loadingObjects.SetActive(true);

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }

    private void PlayerGetPoint()
    {
        playerPoints++;
        serveX = 5.5f;
    }
    
    private void BotGetPoint()
    {
        botPoints++;
        serveX = -5.5f;
    }
}
