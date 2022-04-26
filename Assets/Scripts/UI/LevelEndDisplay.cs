using UnityEngine;

namespace GardenDefense
{
    public class LevelEndDisplay : MonoBehaviour
    {
        [SerializeField] GameObject _losePanel;
        
        Animator _anim;
        BoxCollider2D _buttonBlock;

        private void Awake()
        {
            _losePanel.SetActive(false);
        }

        private void Start()
        {
            _anim = GetComponent<Animator>();
            _buttonBlock = GetComponent<BoxCollider2D>();
            _buttonBlock.enabled = false;

            LevelEndController.onLevelEnded += DisplayWinText;
            LivesDisplay.onGameOver += DisplayLosePanel;
        }

        void DisplayWinText()
        {
            _buttonBlock.enabled = true;
            _anim.SetTrigger("LevelComplete");
        }

        void DisplayLosePanel()
        {
            _buttonBlock.enabled = true;
            _losePanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void OnLevelCompleteAnimationEnded() => FindObjectOfType<LevelLoader>().LoadNextScene();

        private void OnDisable()
        {
            LevelEndController.onLevelEnded -= DisplayWinText;
            LivesDisplay.onGameOver -= DisplayLosePanel;
        }
    }
}
