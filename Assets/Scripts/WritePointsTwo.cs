using TMPro;
using UnityEngine;

public class WritePointsTwo : MonoBehaviour
{
    private TMP_Text tmpText;
    
    private void Start()
    {
        tmpText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        tmpText.text = GameRulesTwo.playerPoints.ToString();
    }
}