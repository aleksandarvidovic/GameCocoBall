using UnityEngine;
using UnityEngine.UI;

public class SetSpriteById : MonoBehaviour
{
    [SerializeField] private int who;

    private Image image;
    private Sprite s;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if(who == 1)
            SetSprite(ButtonsClick.playerSpriteId);
        else
            SetSprite(ButtonsClick.botSpriteId);
    }

    void SetSprite(int id)
    {
        switch (id)
        {
            case 1:
                s = Resources.Load<Sprite>("tiger");
                image.sprite = s;
                break;
            case 2:
                s = Resources.Load<Sprite>("panda");
                image.sprite = s;
                break;
            case 3:
                s = Resources.Load<Sprite>("monkey");
                image.sprite = s;
                break;
            case 4:
                s = Resources.Load<Sprite>("sloth");
                image.sprite = s;
                break;
            case 5:
                s = Resources.Load<Sprite>("wildGoat");
                image.sprite = s;
                break;
            case 6:
                s = Resources.Load<Sprite>("deer");
                image.sprite = s;
                break;
        }
    }
}
