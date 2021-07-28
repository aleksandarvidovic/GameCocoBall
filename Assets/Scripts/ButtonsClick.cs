using UnityEngine;

public class ButtonsClick : MonoBehaviour
{
    [SerializeField] private GameObject exitGame;
    
    public static int playerSpriteId = 1;
    public static int botSpriteId = 1;
    private int maxSprites = 6;

    public void QuitGame()
    {
        SoundManager.PlaySound("click");
        exitGame.SetActive(true);
        Application.Quit();
    }

    public void NextPlayerSprite()
    {
        SoundManager.PlaySound("click");

        if (playerSpriteId < maxSprites)
            playerSpriteId++;
        else
            playerSpriteId = 1;
    }
    
    public void PreviousPlayerSprite()
    {
        SoundManager.PlaySound("click");

        if (playerSpriteId > 1)
            playerSpriteId--;
        else
            playerSpriteId = maxSprites;
    }

    public void NextBotSprite()
    {
        SoundManager.PlaySound("click");

        if (botSpriteId < maxSprites)
            botSpriteId++;
        else
            botSpriteId = 1;
    }
    
    public void PreviousBotSprite()
    {
        SoundManager.PlaySound("click");

        if (botSpriteId > 1)
            botSpriteId--;
        else
            botSpriteId = maxSprites;
    }
}
