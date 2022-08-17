using UnityEngine;
using UnityEngine.UI;

namespace _ACCA.Scripts.Controllers.FormItems
{
    public class ImageForm : MonoBehaviour
    {
        private Texture image;

        [SerializeField] private CameraTake cameraTake;
    
        [SerializeField] private Button takePicture;
    

        private void OnEnable()
        {
            takePicture.onClick.AddListener(TakePicture);
        }

        private void OnDisable()
        {
            takePicture.onClick.RemoveListener(TakePicture);
        }

        private void TakePicture()
        {
            image = cameraTake.TakePicture();
            takePicture.gameObject.SetActive(false);
        }
    }
}
