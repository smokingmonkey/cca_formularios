using UnityEngine;

namespace _ACCA.Scripts.Managers
{
   public class UiReferences : MonoBehaviour
   {
      public static UiReferences Instance;

      private void Awake()
      {
         Instance = this;
      }


      [SerializeField] private GameObject creationPanel;
      [SerializeField] private GameObject visualizerPanel;

      public void OpenVisualizerPanel()
      {
         creationPanel.SetActive(false);
         visualizerPanel.SetActive(true);
      }
   
      public void OpenCreationPanel()
      {
         creationPanel.SetActive(true);
         visualizerPanel.SetActive(false);
      }

   }
}
