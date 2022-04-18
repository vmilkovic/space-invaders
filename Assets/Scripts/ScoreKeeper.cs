using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct HighScore {
    public int round;
    public int score;
}

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int levelEndScore;
    int score;
    List<HighScore> highScores = new List<HighScore>();
    LevelManager levelManager;
    static ScoreKeeper instance;

    void Awake()
    {   
        ManageSingleton();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void ManageSingleton()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(instance != null)
        {
            instance.levelEndScore = levelEndScore;

            if(currentScene.name == "Level1")
            {
                instance.ResetScore();
            }

            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public ScoreKeeper GetInstance()
    {
        return instance;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetHighScore()
    {   
        HighScore highScore = new HighScore();
        highScore.round = highScores.Count + 1;
        highScore.score = score;
        
        highScores.Add(highScore);
    }

    public List<HighScore> GetHighScores()
    {
        return highScores;
    }

   
    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);

        Scene currentScene = SceneManager.GetActiveScene();
        if(levelEndScore <= score && levelEndScore != 0)
        {
            levelManager.LoadGameIndex(currentScene.buildIndex+1);
        }
    }

    public void ResetScore()
    {
        score = 0;
    }
}
