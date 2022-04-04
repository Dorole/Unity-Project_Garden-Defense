using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace GardenDefense
{
    public class LevelLoader : MonoBehaviour
    {
        public static event Action onGameLoaded;
        //public static event Action onMenuLoaded;

        [SerializeField] float _delay = 3;
        int _currentSceneIndex;

        private void Start()
        {
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (_currentSceneIndex == 0)
                Invoke("LoadNextScene", _delay);

            if (_currentSceneIndex == 2)
                onGameLoaded?.Invoke();
            //else if (_currentSceneIndex == 1)
            //    onMenuLoaded?.Invoke();

                Time.timeScale = 1;
        }

        private void Update()
        {
            //Debug purposes
            if (Input.GetKey(KeyCode.R))
                RestartLevel();
        }

        public void LoadNextScene()
        {
            SceneManager.LoadScene(_currentSceneIndex + 1);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");

        }

        public void LoadOptionsScreen()
        {
            SceneManager.LoadScene("OptionsScreen");
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(_currentSceneIndex);
        }

        public void Quit()
        {
//add for editor
            Application.Quit();
        }
    }
}
