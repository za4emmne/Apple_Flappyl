using UnityEngine.UI;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Text _score;

    private void OnEnable()
    {
        _scoreCounter.Changed += OnChange;
    }

    private void OnDisable()
    {
        _scoreCounter.Changed -= OnChange;
    }

    private void OnChange(int score)
    {
        _score.text = score.ToString();
    }
}
