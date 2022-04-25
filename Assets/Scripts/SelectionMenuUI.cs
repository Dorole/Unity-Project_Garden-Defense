using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GardenDefense
{
    public class SelectionMenuUI : MonoBehaviour
    {
        [SerializeField] Button[] _levelButtons;
        LevelSelector _selector;

        private void Start()
        {
            _selector = FindObjectOfType<LevelSelector>();
            SetButtonText();
        }

        void SetButtonText()
        {
            for (int i = 0; i < _levelButtons.Length; i++)
                _levelButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
        }
    }
}
