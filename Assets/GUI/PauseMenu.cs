using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public static bool _isGamePaused = false;
    [SerializeField] public GameObject _pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Spacja");
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("KeyCode.Escape");
            if (_isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
        }
    }

    void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _isGamePaused = false;
    }
    void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isGamePaused = true;
    }
}