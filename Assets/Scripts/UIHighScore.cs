using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        List<HighScore> highScores = scoreKeeper.GetHighScores();
        if(highScores.Count > 0)
        {
            highScores.Sort((x, y) => x.score.CompareTo(y.score));
            highScores.Reverse();

            int range = highScores.Count < 20 ? highScores.Count : 20;
            highScores = highScores.GetRange(0, range);

            highScoreText.text = "";

            foreach(HighScore highScore in highScores)
            {
                highScoreText.text += "round " + highScore.round + " - " + highScore.score + "\n";
            }
        }
    }
}
