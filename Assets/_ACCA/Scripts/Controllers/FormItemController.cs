using System;
using _ACCA.Scripts.Controllers.FormItems;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _ACCA.Scripts.Controllers
{
    public class FormItemController : MonoBehaviour
    {
        public static event Action OnNewForm;
        public static event Action<TextForm> OnNewTextForm;

        [SerializeField] private TMP_InputField tittle;


        [SerializeField] private Button newFormButton;
        [SerializeField] private Button cancelNewFormButton;
        [SerializeField] private Button newTextFormButton;
        [SerializeField] private Button newPictureFormButton;
        [SerializeField] private Button newTableFormButton;

        [SerializeField] private GameObject textForm;
        [SerializeField] private GameObject pictureForm;
        [SerializeField] private GameObject tableForm;
    
        [SerializeField] private GameObject optionsButtons;

        private void OnEnable()
        {
            newFormButton.onClick.AddListener(NewForm);
            newTextFormButton.onClick.AddListener(NewTextForm);
            newTableFormButton.onClick.AddListener(NewTableForm);
            newPictureFormButton.onClick.AddListener(NewPictureForm);
        }

    

        private void OnDisable()
        {
            newFormButton.onClick.RemoveListener(NewForm);
        
            newTextFormButton.onClick.RemoveListener(NewTextForm);
            newTableFormButton.onClick.RemoveListener(NewTableForm);
            newPictureFormButton.onClick.RemoveListener(NewPictureForm);
        }

        void NewForm()
        {
            OnNewForm?.Invoke();
            newFormButton.GameObject().SetActive(false);
        }

        void NewTextForm()
        {
            textForm.SetActive(true);
            newFormButton.GameObject().SetActive(true);
            cancelNewFormButton.gameObject.SetActive(false);
            optionsButtons.SetActive(false);
            var tF = textForm.GetComponent<TextForm>();
            tF.tittle.text = tittle.text;
        
            OnNewTextForm?.Invoke(tF);
        }
        private void NewPictureForm()
        {
            pictureForm.SetActive(true);
            newFormButton.GameObject().SetActive(true);
            cancelNewFormButton.gameObject.SetActive(false);
            optionsButtons.SetActive(false);
        }
    
        private void NewTableForm()
        {
            tableForm.SetActive(true);
            newFormButton.GameObject().SetActive(true);
            cancelNewFormButton.gameObject.SetActive(false);
            optionsButtons.SetActive(false);
        }
    }
}