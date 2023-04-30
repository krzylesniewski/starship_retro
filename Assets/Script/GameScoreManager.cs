using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public static int _gameScore = 0;
    [SerializeField] public TextMeshProUGUI _gameScoreText;

    void Start()
    {
        ResetGameScoreUI();
    }

    void Update()
    {
        _gameScoreText.text = $"{_gameScore}";
    }

    public void UpdateGameScoreUI(int vaule)
    {
        _gameScore += vaule;
    }

    public void ResetGameScoreUI()
    {
        _gameScore = 0;
    }

    public int GetCurrentScore() {
        return _gameScore;
    }
}
