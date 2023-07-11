using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BTK_Academy_DigitalGame_Course.Manager
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] GameObject _pauseUI, _inGameScreen;
        public void PlayGame(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
            Time.timeScale = 1f;
        }

        public void PauseGame()
        {
            Time.timeScale = 0f;
            _inGameScreen.SetActive(false);
            _pauseUI.SetActive(true);
        }

        public void RePlay()
        {
            Time.timeScale = 1f;
            PlayGame(1);
        }

        public void ResumeGame()
        {
            Time.timeScale = 1f;
            _pauseUI.SetActive(false);
            _inGameScreen.SetActive(true);
        }

        public void BackToMainMenu()
        {
            Time.timeScale = 1f;
            DataManager.Instance.SaveData();
            SceneManager.LoadScene(0);
        }
    }
}

