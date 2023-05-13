using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreResult : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _scoreResultText;
    [SerializeField] private TMP_Text _highScoreResultText;
    private int _scoreNumber;

    private void OnEnable()
    {
        _scoreNumber = _score.ScoreNumber;
        _scoreResultText.text = _scoreNumber.ToString();
        SavingHighScore();
    }

    private void SavingHighScore()
    {
        
        if (_score.ScoreNumber > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _score.ScoreNumber);
            Debug.Log("_highScoreResultText.text");
        }
        
        _highScoreResultText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
