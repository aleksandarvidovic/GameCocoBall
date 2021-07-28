using Photon.Pun;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerTwo : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private SpriteRenderer sr;
    private Sprite s;
    private Rigidbody2D rb;
    private bool onSand;
    private PhotonView view;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        SetSprite(6);
        view = GetComponent<PhotonView>();
    }
    
    private void Update()
    {
        if (view.IsMine)
        {
            if (CrossPlatformInputManager.GetButton("Left"))
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            else if (CrossPlatformInputManager.GetButton("Right"))
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            else
                rb.velocity = new Vector2(0, rb.velocity.y);

            if (CrossPlatformInputManager.GetButtonDown("Switch"))
                view.RPC("SwitchSprite", RpcTarget.AllBuffered, null);
        }
    }

    private void FixedUpdate()
    {
        if (rb.position.x < -0.35)
            rb.position = new Vector2(2, -2.2f);
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
    
    [PunRPC]
    void SwitchSprite()
    {
        if (ButtonsClick.botSpriteId > 1)
            ButtonsClick.botSpriteId--;
        else
            ButtonsClick.botSpriteId = 6;
                
        SetSprite(ButtonsClick.botSpriteId);
    }
}
