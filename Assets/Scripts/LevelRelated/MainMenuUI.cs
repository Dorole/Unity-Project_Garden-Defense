using UnityEngine;

namespace GardenDefense
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] GameObject _aboutPanel;
        [SerializeField] GameObject _buttonGroup;

        private void Start()
        {
            _aboutPanel.SetActive(false);
        }

        public void TogglePanelActive()
        {
            _aboutPanel.SetActive(!_aboutPanel.activeSelf);
            _buttonGroup.SetActive(!_buttonGroup.activeSelf);
        }
    }
}
