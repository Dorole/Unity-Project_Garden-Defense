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
        
        [SerializeField] int _mainMenuIndex = 1;
        int _currentSceneIndex;
        int _levelToLoad;        
        public int CurrentSceneIndex => _currentSceneIndex;

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
        public void FadeToLevel(int levelIndex)
        {
            _levelToLoad = levelIndex;
            _animator.SetTrigger("FadeOut");
        }
        public void LoadLevel() => SceneManager.LoadScene(_levelToLoad);

        public void RestartLevel() => FadeToLevel(_currentSceneIndex);
        
        public void FadeInEnded() => onLevelFadeIn?.Invoke();

        public void Quit() => Application.Quit();

        public void LoadMainMenu() => FadeToLevel(_mainMenuIndex);

    }
}
