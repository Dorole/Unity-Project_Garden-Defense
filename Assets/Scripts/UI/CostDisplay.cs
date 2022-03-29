using UnityEngine;
using TMPro;

namespace GardenDefense
{
    public class CostDisplay : MonoBehaviour
    {
        [SerializeField] Defender _defender;
        TextMeshProUGUI _costText;

        private void Start()
        {
            _costText = GetComponent<TextMeshProUGUI>();
            _costText.text = _defender.Cost.ToString();
        }
    }
}
