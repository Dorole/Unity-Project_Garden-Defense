using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace GardenDefense
{
    public class LevelLoader : MonoBehaviour
    {
        public static event Action onGameLoaded;
        public static event Action onLevelFadeIn;

        [SerializeField] float _delay = 3;
        [SerializeField] Animator _animator;
        int _currentSceneIndex;
        int _levelToLoad;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (_currentSceneIndex == 0)
                Invoke("LoadNextScene", _delay);

            if (_currentSceneIndex == 2)
                onGameLoaded?.Invoke();

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
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            FadeToLevel(nextLevel);
        }

        public void LoadMainMenu() => FadeToLevel(1);

        public void LoadOptionsScreen() => FadeToLevel(SceneManager.sceneCountInBuildSettings - 1);

        public void RestartLevel() => FadeToLevel(_currentSceneIndex);

        public void Quit() => Application.Quit();

        private void FadeToLevel(int levelIndex)
        {
            _levelToLoad = levelIndex;
            _animator.SetTrigger("FadeOut");
        }

        public void LoadLevel() => SceneManager.LoadScene(_levelToLoad);

        public void FadeInEnded() => onLevelFadeIn?.Invoke();
    }
}
