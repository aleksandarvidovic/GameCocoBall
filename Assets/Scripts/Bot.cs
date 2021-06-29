using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float centerX;
    [SerializeField] private float botAndBallSpaceX;
    [SerializeField] private float botAndBallSpaceY;

    private SpriteRenderer sr;
    private Sprite s;
    private Rigidbody2D rb;
    private bool onSand;
    private Ball ball;
    private Vector2 moveDirection;
    bool isBallInCourt;
    private bool willJump;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        SetSprite(ButtonsClick.botSpriteId);
        ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        if (ball.transform.position.x > centerX)
            isBallInCourt = true;
        else
            isBallInCourt = false;

        if (ball.transform.position.x > rb.transform.position.x - botAndBallSpaceX &&
            ball.transform.position.x < rb.transform.position.x + botAndBallSpaceX &&
            ball.transform.position.y - rb.transform.position.y < botAndBallSpaceY)
            willJump = true;
        else
            willJump = false;

        if (willJump && onSand)
            rb.AddForce(Vector2.up * jumpForce);
    }
    
    private void FixedUpdate()
    {
        if (rb.position.x < centerX)
            rb.position = new Vector2(2, -2.2f);
        
        if(isBallInCourt)
            FollowBall();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Background background = other.gameObject.GetComponent<Background>();

        if (background != null)
            onSand = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Background background = other.gameObject.GetComponent<Background>();

        if (background != null)
            onSand = false;
    }
    
    private void FollowBall()
    {
        moveDirection = (ball.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, rb.velocity.y);
    }
    
    void SetSprite(int id)
    {
        switch (id)
        {
            case 1:
                s = Resources.Load<Sprite>("tiger");
                sr.sprite = s;
                break;
            case 2:
                s = Resources.Load<Sprite>("panda");
                sr.sprite = s;
                break;
            case 3:
                s = Resources.Load<Sprite>("monkey");
                sr.sprite = s;
                break;
            case 4:
                s = Resources.Load<Sprite>("sloth");
                sr.sprite = s;
                break;
            case 5:
                s = Resources.Load<Sprite>("wildGoat");
                sr.sprite = s;
                break;
            case 6:
                s = Resources.Load<Sprite>("deer");
                sr.sprite = s;
                break;
        }
    }
}
