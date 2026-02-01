using System;
using UnityEngine;

public class KillTracker : MonoBehaviour
{

    [SerializeField]
    GameEventFloat onProgressUpdate;

    [SerializeField]
    GameEvent onWin;

    [SerializeField]
    int initalScore;

    [SerializeField]
    int scoreForWin;

    float progress = 0;

    int currentScore = 0;

    float Progress
    {
        get => progress;
        set
        {
            progress = value;
            onProgressUpdate.Invoke(progress);
            if (progress >= 1)
            {
                onWin.Invoke();
            }
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentScore = initalScore;
        UpdateProgress();
    }

    public void AddScore(int toAdd)
    {
        currentScore += toAdd;
        currentScore = currentScore > scoreForWin ? scoreForWin : currentScore;
        UpdateProgress();
    }

    public void EnemyDefeated(EnemyDeathInfo info)
    {
        AddScore(info.ColorMatched ? info.EnemyStatsSO.Points * 2 : info.EnemyStatsSO.Points);
    }

    public void PlayerHit()
    {
        RemoveScore(currentScore / 2);
    }

    private void UpdateProgress()
    {
        Progress = 1.0f * currentScore / scoreForWin;
    }

    public void RemoveScore(int toRemove)
    {
        currentScore -= toRemove;
        currentScore = currentScore < 0 ? 0 : currentScore;
        UpdateProgress();
    }
}
