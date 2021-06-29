using TMPro;
using UnityEngine;

public class ScoreTwoPlayers : MonoBehaviour
{
    [SerializeField] private int who;

    private void Start()
    {
        GameRulesTwo.playerPoints = 0;
        GameRulesTwo.player2Points = 0;
        
        TMP_Text tmpText = GetComponent<TMP_Text>();

        if (who == 1)
            tmpText.text = GameRulesTwo.playerPointsEnd.ToString();
        else
            tmpText.text = GameRulesTwo.player2PointsEnd.ToString();
    }
}