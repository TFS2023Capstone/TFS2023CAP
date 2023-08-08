using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace HiddenWorld.CanvasManager
{ 
public class CanvasManager : MonoBehaviour
{
    //public AudioMixer audioMixer;
    //public AudioMixer sfxMixer;

   // [Header("Button")]
    //public Button startButton;
    //public Button settingsButton;
   // public Button quitButton;
    //public Button returnToMenuButton;
   // public Button returnToGameButton;

    [Header("Menus")]
        public GameObject journal;
       // public GameObject mainMenu;
       // public GameObject settingsMenu;
       // public GameObject pauseMenu;
       //public GameObject gameOverMenu;
       //public GameObject winMenu;

        //[Header("Text")]
        //public Text musicSliderText;
        // public Text sfxSliderText;

        // [Header("Slider")]
        // public Slider musicVolSlider;
        // public Slider sfxVolSlider;

        /*public void StartGame()
          {
              SceneManager.LoadScene("Level");
              Time.timeScale = 1;
          }

          void ShowSettingsMenu()
          {
              mainMenu.SetActive(false);
              settingsMenu.SetActive(true);
              gameOverMenu.SetActive(false);
              winMenu.SetActive(false);
          }

          public void ShowMainMenu()
          {
              if (SceneManager.GetActiveScene().name == "Level")
              {
                  SceneManager.LoadScene("Title");
              }
              mainMenu.SetActive(true);
              settingsMenu.SetActive(true);
              gameOverMenu.SetActive(false);
              winMenu.SetActive(false);
          }

          void OnMusicSliderValueChanged(float value)
          {
              if (musicSliderText)
              {
                  musicSliderText.text = value.ToString();
                  audioMixer.SetFloat("MusicVol", value - 80);
              }
          }

          void OnSfxSliderValueChanged(float value)
          {
              if (sfxSliderText)
              {
                  sfxSliderText.text = value.ToString();
                  audioMixer.SetFloat("SFXVol", value - 80);
              }
          }

          void PauseGame()
          {
              pauseMenu.SetActive(true);
              settingsMenu.SetActive(true);
              winMenu.SetActive(false);
              Time.timeScale = 0;
          }

          void ResumeGame()
          {
              pauseMenu.SetActive(false);
              settingsMenu.SetActive(false);
              winMenu.SetActive(false);
              Time.timeScale = 1;
          }

          void QuitGame()
          {
              #if UNITY_EDITOR
                  UnityEditor.EditorApplication.isPlaying = false;
              #else
                  Application.Quit();
              #endif
          }

          void GameOver()
          {
              Time.timeScale = 0;
              SceneManager.LoadScene("GameOver");
              mainMenu.SetActive(false);
              settingsMenu.SetActive(false);
              winMenu.SetActive(false);
              gameOverMenu.SetActive(true);
          }

          // Start is called before the first frame update
          void Start()
          {
              if (startButton)
                  startButton.onClick.AddListener(StartGame);

              if (settingsButton)
                  settingsButton.onClick.AddListener(ShowSettingsMenu);

              if (quitButton)
                  quitButton.onClick.AddListener(QuitGame);

              if (returnToMenuButton)
                  returnToMenuButton.onClick.AddListener(ShowMainMenu);

              if (returnToGameButton)
                  returnToGameButton.onClick.AddListener(ResumeGame);

              if (musicVolSlider)
              {
                  musicVolSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
                  float mixerValue;
                  audioMixer.GetFloat("MusicVol", out mixerValue);
                  musicVolSlider.value = mixerValue + 80;
              }

              if (sfxVolSlider)
              {
                  sfxVolSlider.onValueChanged.AddListener(OnSfxSliderValueChanged);
                  float mixerValue;
                  audioMixer.GetFloat("SFXVol", out mixerValue);
                  sfxVolSlider.value = mixerValue + 80;
              }
          }

          // Update is called once per frame
          void Update()
          {
              if (pauseMenu)
              {
                  if (Input.GetKeyDown(KeyCode.P))
                  {
                      pauseMenu.SetActive(!pauseMenu.activeSelf);
                      PauseGame();
                  }
              }        
          }*/
    }
}
