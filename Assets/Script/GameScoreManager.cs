using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int _gameScore = 0;
    [SerializeField] public TextMeshProUGUI _gameScoreText;

    void Start()
    {
        ResetGameScoreUI();
    }

    void Update()
    {
        _gameScoreText.text = _gameScore.ToString();
    }

    public void UpdateGameScoreUI(int vaule)
    {
        Debug.Log(" ====>>>>> UpdateGameScoreUI:");
        Debug.Log(vaule);
        _gameScore += vaule;
        Debug.Log(_gameScore);
        Debug.Log(_gameScoreText);
        // _gameScoreText.SetText($"{_gameScore}");
    }

    public void ResetGameScoreUI()
    {
        Debug.Log("ResetGameScoreUI");
        _gameScore = 0;
        // _gameScoreText.text = $"{_gameScore}";
    }

    public int GetCurrentScore() {
        return _gameScore;
    }
}
