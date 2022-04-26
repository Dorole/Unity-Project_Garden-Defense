using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GardenDefense
{
    public class SelectionMenuUI : MonoBehaviour
    {
        [SerializeField] Button[] _levelButtons;

        private void Start()
        {
            SetButtonText();
            SetInteractable();
        }

        void SetButtonText()
        {
            for (int i = 0; i < _levelButtons.Length; i++)
                _levelButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
        }

        void SetInteractable()
        {
            int levelReached;

            if (PlayerPrefsController.CheckForUnlockLevelKey())
                levelReached = PlayerPrefsController.GetLevelToUnlock();
            else
                levelReached = 2;                                       //lvl 1 build index = 2;

            for (int i = 0; i < _levelButtons.Length; i++)
            {
                if (i + 2 > levelReached)                   
                    _levelButtons[i].interactable = false;
            }
        }
    }
}
