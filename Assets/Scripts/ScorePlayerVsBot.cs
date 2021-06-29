using TMPro;
using UnityEngine;

public class ScorePlayerVsBot : MonoBehaviour
{
    [SerializeField] private int who;

    private void Start()
    {
        GameRules.playerPoints = 0;
        GameRules.botPoints = 0;
        
        TMP_Text tmpText = GetComponent<TMP_Text>();

        if (who == 1)
            tmpText.text = GameRules.playerPointsEnd.ToString();
        else
            tmpText.text = GameRules.botPointsEnd.ToString();
    }
}
