using TMPro;
using UnityEngine;

public class WritePoints : MonoBehaviour
{
    private TMP_Text tmpText;
    
    private void Start()
    {
        tmpText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        tmpText.text = GameRules.playerPoints.ToString();
    }
}
