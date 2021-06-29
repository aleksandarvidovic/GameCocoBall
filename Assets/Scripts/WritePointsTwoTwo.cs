using TMPro;
using UnityEngine;

public class WritePointsTwoTwo : MonoBehaviour
{
    private TMP_Text tmpText;
    
    private void Start()
    {
        tmpText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        tmpText.text = GameRulesTwo.player2Points.ToString();
    }
}