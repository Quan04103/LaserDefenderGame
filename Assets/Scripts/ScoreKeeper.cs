using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore = 0;
    static ScoreKeeper instance;
    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }
    public void AddToScore(int score)
    {
        Debug.Log("Score added: " + score);
        currentScore += score;
    }
    public void ResetScore()
    {
        currentScore = 0;
    }
}
