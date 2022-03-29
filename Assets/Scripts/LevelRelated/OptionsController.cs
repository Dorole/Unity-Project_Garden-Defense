using UnityEngine;
using UnityEngine.UI;

namespace GardenDefense
{
    public class OptionsController : MonoBehaviour
    {   
        [SerializeField] Slider _volumeSlider;
        [SerializeField] float _defaultVolume = 0.5f;
        AudioPlayer _audioPlayer;

        [SerializeField] Slider _difficultySlider;
        [SerializeField] float _defaultDifficulty = 0f;

        private void Start()
        {
            _audioPlayer = FindObjectOfType<AudioPlayer>();
            
            if (!_audioPlayer)
                Debug.LogWarning("No audio player in the scene!");
            
            _volumeSlider.value = PlayerPrefsController.GetMasterVolume();

            CheckForPlayerPrefsKeys();
        }

        private void Update()
        {
            if (_audioPlayer)
                _audioPlayer.SetVolume(_volumeSlider.value);
        }

        private void CheckForPlayerPrefsKeys()
        {
            if (!PlayerPrefsController.CheckForVolumeKey())
            {
                _volumeSlider.value = _defaultVolume;
                _audioPlayer.SetVolume(_volumeSlider.value);
                PlayerPrefsController.SetMasterVolume(_volumeSlider.value);
            }

            if (!PlayerPrefsController.CheckForDifficultyKey())
            {
                _difficultySlider.value = _defaultDifficulty;
                PlayerPrefsController.SetDifficulty(_difficultySlider.value);
            }
        }

        public void SetDefaultValues()
        {
            _volumeSlider.value = _defaultVolume;
            _difficultySlider.value = _defaultDifficulty;
        }

        public void SavePrefs()
        {
            PlayerPrefsController.SetMasterVolume(_volumeSlider.value);
            PlayerPrefsController.SetDifficulty(_difficultySlider.value);
        }
    }
}
