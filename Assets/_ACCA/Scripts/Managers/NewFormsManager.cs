using System.Collections.Generic;
using _ACCA.Scripts.Controllers;
using _ACCA.Scripts.Controllers.FormItems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _ACCA.Scripts.Managers
{
    public class NewFormsManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField tittle;

        [SerializeField] private GameObject formPrefab;
        [SerializeField] private Transform formsParent;


        [SerializeField] private FormDataManager formDataManager;

        private List<GameObject> forms;

        private int orderInFormulary;
    
    
        private List<GameObject> formsGameObjects = new();


        [SerializeField] private Button clearFormButton;
        [SerializeField] private Button saveFormButton;

        private void OnEnable()
        {
            FormItemController.OnNewForm += AddNewFormItem;
            FormItemController.OnNewTextForm += RegisterNewTextForm;
        
            clearFormButton.onClick.AddListener(ClearForms);
            //saveFormButton.onClick.AddListener(ClearForms);
        }

        private void OnDisable()
        {
            FormItemController.OnNewForm -= AddNewFormItem;
            FormItemController.OnNewTextForm -= RegisterNewTextForm;
        
            clearFormButton.onClick.RemoveListener(ClearForms);
            //saveFormButton.onClick.RemoveListener(ClearForms);
        }

        private void Start()
        {
            AddNewFormItem();
        }

        void AddNewFormItem()
        {
            var itemGameObject = Instantiate(formPrefab, formsParent);
            formsGameObjects.Add(itemGameObject);
            orderInFormulary++;
        }

        private void RegisterNewTextForm(TextForm obj)
        {
            obj.orderInFormulary = orderInFormulary;

            formDataManager.RegisterNewTextForm(obj);
        }


        void ClearForms()
        {
            foreach (var formsGameObject in formsGameObjects)
            {
                Destroy(formsGameObject);
            }

            orderInFormulary = 0;

            tittle.text = "";
        
            AddNewFormItem();
        }
    }
}