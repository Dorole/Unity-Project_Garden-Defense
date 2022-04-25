using UnityEngine;

namespace GardenDefense
{
    public class LevelSelector : MonoBehaviour
    {
        LevelLoader _loader;

        private void Start()
        {
            _loader = FindObjectOfType<LevelLoader>();
        }

        public void Select (int levelIndex)
        {
            _loader.FadeToLevel(levelIndex);
        }
    }
}
