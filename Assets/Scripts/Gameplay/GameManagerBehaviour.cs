using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField]
    private static bool _gameOver = false;
    [SerializeField]
    private HealthBehaviour _playerHealth;
    [SerializeField]
    private GameObject _gameOverScreen;
    [SerializeField]
    private GameObject _pauseButton;
    [SerializeField]
    private GameObject _resumeButton;
    public static bool GameOver { get { return _gameOver; } }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        _gameOverScreen.SetActive(true);
        _pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        _gameOverScreen.SetActive(false);
        _pauseButton.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        _gameOver = _playerHealth.Health <= 0;
        _gameOverScreen.SetActive(_gameOver);
        _resumeButton.SetActive(!_gameOver);
    }
}
