using UnityEngine;

namespace _ACCA.Scripts.Utilities
{
    public class PlayerPrefsUtils : MonoBehaviour
    {
        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
