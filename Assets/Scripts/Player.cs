using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private SpriteRenderer sr;
    private Sprite s;
    private Rigidbody2D rb;
    private bool onSand;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        SetSprite(ButtonsClick.playerSpriteId);
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButton("Left"))
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        else if (CrossPlatformInputManager.GetButton("Right"))
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
        
        if(CrossPlatformInputManager.GetButtonDown("Up") && onSand)
            rb.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        if (rb.position.x > -0.35)
            rb.position = new Vector2(-2, -2.2f);
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
