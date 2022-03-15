using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] public Text ScoreTextTemp;
    static private Text ScoreText;
    static int Score = 0;

    void Start()
    {
        SetObject();
    }

    void SetObject()
    {
        ScoreText = ScoreTextTemp;
    }

    static public void SetScorePlus()
    {
        if(Score <= 99990000) Score += 1000 + (500 * LevelBonus());
        SetChangeText();
    }

    static int LevelBonus()
    {
        return 0 <= (Score / 8000) ? (Score / 8000) : 0;
    }

    static public void SetChangeText()
    {
        ScoreText.text = "SCOREF" + Score.ToString("00000000");
    }

    static public void ScoreReset()
    {
        Score = 0;
        SetChangeText();
    }
}
