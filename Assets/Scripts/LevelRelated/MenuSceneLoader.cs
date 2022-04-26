using UnityEngine;
using UnityEngine.SceneManagement;

namespace GardenDefense
{
    public class MenuSceneLoader : MonoBehaviour
    {
        LevelLoader _loader;
        [SerializeField] int _optionsSceneIndex;
        [SerializeField] int _levelSelectionSceneIndex;

        private void Start()
        {
            _loader = FindObjectOfType<LevelLoader>();
        }

        public void LoadOptionsScreen() => _loader.FadeToLevel(_optionsSceneIndex);

        public void LoadSelectionScreen() => _loader.FadeToLevel(_levelSelectionSceneIndex);
    }
}
