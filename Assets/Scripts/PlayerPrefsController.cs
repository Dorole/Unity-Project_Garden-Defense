using UnityEngine;

namespace GardenDefense
{
    public class PlayerPrefsController : MonoBehaviour
    {
        const string MASTER_VOLUME_KEY = "Master volume";
        const string DIFFICULTY_KEY = "Difficulty";
        const string UNLOCK_LEVEL_KEY = "Unlock level";

        const float MIN_VOLUME = 0f;
        const float MAX_VOLUME = 1f;

        const float MIN_DIFFICULTY = 0f;
        const float MAX_DIFFICULTY = 2f;

        public static void SetMasterVolume(float volume)
        {
            if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
            {
                Debug.Log("Master volume set to " + volume);
                PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
            }
            else
                Debug.LogError("Master volume is out of range.");
        }

        public static float GetMasterVolume()
        {
            return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        }

        public static bool CheckForVolumeKey()
        {
            return PlayerPrefs.HasKey(MASTER_VOLUME_KEY);
        }

        public static void SetDifficulty(float difficulty)
        {
            if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
            {
                Debug.Log("Difficulty set to " + difficulty);
                PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
            }
            else
                Debug.LogError("Difficulty value is out of range.");
        }

        public static float GetDifficulty()
        {
            return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
        }

        public static bool CheckForDifficultyKey()
        {
            return PlayerPrefs.HasKey(DIFFICULTY_KEY);
        }

        public static void SetLevelToUnlock(int index)
        {
            PlayerPrefs.SetInt(UNLOCK_LEVEL_KEY, index);
        }

        public static int GetLevelToUnlock()
        {
            return PlayerPrefs.GetInt(UNLOCK_LEVEL_KEY);
        }

        public static bool CheckForUnlockLevelKey()
        {
            return PlayerPrefs.HasKey(UNLOCK_LEVEL_KEY);
        }
    }
}
