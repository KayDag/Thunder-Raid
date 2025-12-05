using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class HighScoreUI : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts;

    public void ShowScores(List<int> scores)
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < scores.Count)
                scoreTexts[i].text = scores[i].ToString();
            else
                scoreTexts[i].text = "-";
        }
    }
}
