using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormsManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField tittle;
    
    [SerializeField] private GameObject formPrefab;
    [SerializeField] private Transform formsParent;


    [SerializeField] private FormDataManager formDataManager;
    
    private List<GameObject> forms;

    private int orderInFormulary;

    private void OnEnable()
    {
        FormController.OnNewForm += AddNewForm;
        FormController.OnNewTextForm += RegisterNewTextForm;
    }

   

    private void OnDisable()
    {
        FormController.OnNewForm -= AddNewForm;
        FormController.OnNewTextForm -= RegisterNewTextForm;

    }

    void AddNewForm()
    {
        Instantiate(formPrefab, formsParent);
        orderInFormulary++;
    }
    
    private void RegisterNewTextForm(TextForm obj)
    {
        obj.orderInFormulary = orderInFormulary;
        
        formDataManager.RegisterNewTextForm(obj);
    }
}