using UnityEngine.UI;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Text _score;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += OnChangeScore;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= OnChangeScore;
    }

    private void OnChangeScore(int score)
    {
        _score.text = score.ToString();
    }
}
