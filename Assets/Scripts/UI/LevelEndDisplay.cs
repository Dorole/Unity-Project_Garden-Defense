using UnityEngine;

namespace GardenDefense
{
    public class LevelEndDisplay : MonoBehaviour
    {
        [SerializeField] GameObject _winText;
        [SerializeField] GameObject _losePanel;
        
        Animator _anim;
        BoxCollider2D _buttonBlock;

        private void Awake()
        {
            _winText.SetActive(false);
            _losePanel.SetActive(false);
        }

        private void Start()
        {
            _anim = _winText.GetComponent<Animator>();
            _buttonBlock = GetComponent<BoxCollider2D>();
            _buttonBlock.enabled = false;

            LevelEndController.onLevelEnded += DisplayWinText;
            LivesDisplay.onGameOver += DisplayLosePanel;
        }

        void DisplayWinText()
        {
            _buttonBlock.enabled = true;
            _winText.SetActive(true);
            _anim.SetTrigger("LevelComplete");
        }

        void DisplayLosePanel()
        {
            _buttonBlock.enabled = true;
            _losePanel.SetActive(true);
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            LevelEndController.onLevelEnded -= DisplayWinText;
            LivesDisplay.onGameOver -= DisplayLosePanel;
        }
    }
}
