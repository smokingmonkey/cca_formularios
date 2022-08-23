using System.Collections.Generic;
using _ACCA.Scripts.Controllers;
using _ACCA.Scripts.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _ACCA.Scripts.Managers
{
    public class OpenFormsManager : MonoBehaviour
    {
        public static OpenFormsManager Instance;

        [SerializeField] private TMP_Text tittle;

        [SerializeField] private GameObject formularyPrefab;

        [SerializeField] private GameObject parent;

        private List<GameObject> formsItemsGameObjects = new List<GameObject>();
    
        [SerializeField] Button returnButton;

        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            returnButton.onClick.AddListener(ClearOpenedForm);
        }

        private void OnDisable()
        {
            returnButton.onClick.RemoveListener(ClearOpenedForm);
        }


        public void OpenForm(FormData formData)
        {
            UiReferences.Instance.OpenVisualizerPanel();

            tittle.text = formData.tittle;
        
            foreach (var item in formData.textDataList)
            {
                GameObject newForm = Instantiate(formularyPrefab, parent.transform);
            
                formsItemsGameObjects.Add(newForm);

                var controller = newForm.GetComponent<FormOptionsInstancer>();

                controller.NewTextForm(item.tittle, item.content);
            }
        }

        public void ClearOpenedForm()
        {
            foreach (var formsItemsGameObject in formsItemsGameObjects)
            {
                Destroy(formsItemsGameObject);
            }
        }
    }
}