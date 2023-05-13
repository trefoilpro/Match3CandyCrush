using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _scoreNumber;

    public void AddScore(int score)
    {
        _scoreNumber += score;
        _scoreText.text = _scoreNumber.ToString();
    }

    public void ResetScore()
    {
        _scoreNumber = 0;
        _scoreText.text = _scoreNumber.ToString();
    }
}
