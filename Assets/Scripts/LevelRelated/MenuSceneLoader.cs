using UnityEngine;
using UnityEngine.SceneManagement;

namespace GardenDefense
{
    public class MenuSceneLoader : MonoBehaviour
    {
        LevelLoader _loader;
        [SerializeField] int _optionsSceneIndex;
        [SerializeField] int _levelSelectionSceneIndex;
        [SerializeField] int _firstLevelIndex;

        private void Start()
        {
            _loader = FindObjectOfType<LevelLoader>();
        }

        public void LoadOptionsScreen() => _loader.FadeToLevel(_optionsSceneIndex);

        public void LoadSelectionScreen() => _loader.FadeToLevel(_levelSelectionSceneIndex);

        public void StartNewGame()
        {
            PlayerPrefsController.SetLevelToUnlock(_firstLevelIndex);
            _loader.FadeToLevel(_firstLevelIndex);
        }
    }
}
