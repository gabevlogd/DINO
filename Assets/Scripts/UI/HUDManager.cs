using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private int m_score = 0;

    private void Awake()
    {
        GameManager.EventManager.Register(Enumerators.Event.UpdateScore, SetScore);
        GameManager.EventManager.Register(Enumerators.Event.ResetMatch, ResetScore);
    }

    public void SetScore()
    {
        m_score += 100;
        SetHUDScore();
    }

    public void ResetScore()
    {
        m_score = 0;
        SetHUDScore();
    }

    private void SetHUDScore() => ScoreText.text = "SCORE: " + m_score.ToString();
}
