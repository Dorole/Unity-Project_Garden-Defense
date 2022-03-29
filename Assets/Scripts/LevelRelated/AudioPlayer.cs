using UnityEngine;

namespace GardenDefense
{
    public class AudioPlayer : MonoBehaviour
    {
        private static AudioPlayer instance;
        AudioSource _audioSource;

        [SerializeField] AudioClip _menuMusic;
        [SerializeField] AudioClip _levelMusic;
        [SerializeField] AudioClip _winMusic;

        private void Awake()
        {
            if (!instance)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.volume = PlayerPrefsController.GetMasterVolume();

            //LevelLoader.onMenuLoaded += PlayMenuMusic;
            LevelLoader.onGameLoaded += PlayLevelMusic;
            LevelEndController.onLevelEnded += PlayWinMusic;
        }

        public void SetVolume (float volume)
        {
            _audioSource.volume = volume;
        }

        private void PlayMenuMusic()
        {
            _audioSource.clip = _menuMusic;
            _audioSource.loop = true;
            _audioSource.Play();
        }

        private void PlayLevelMusic()
        {
            _audioSource.clip = _levelMusic;
            _audioSource.loop = true;
            _audioSource.Play();
        }

        void PlayWinMusic()
        {
            _audioSource.clip = _winMusic;
            _audioSource.loop = false;
            _audioSource.Play();
        }

        private void OnDisable()
        {
            //LevelLoader.onMenuLoaded -= PlayMenuMusic;
            LevelLoader.onGameLoaded -= PlayLevelMusic;
            LevelEndController.onLevelEnded -= PlayWinMusic;
        }
    }
}
