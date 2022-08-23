using _ACCA.Scripts.Controllers.FormItems;
using UnityEngine;

namespace _ACCA.Scripts.Controllers
{
    public class FormOptionsInstancer : MonoBehaviour
    {
        [SerializeField] private GameObject textForm;
        [SerializeField] private GameObject pictureForm;
        [SerializeField] private GameObject tableForm;
    
        public void NewTextForm(string tittle, string content)
        {
            textForm.SetActive(true);
      
            var tF = textForm.GetComponent<TextForm>();
            tF.tittle.text = tittle;
            tF.content.text = content;
        }
    }
}