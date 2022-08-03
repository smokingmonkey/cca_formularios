using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormsManager : MonoBehaviour
{
    [SerializeField] private GameObject formPrefab;
    [SerializeField] private Transform formsParent;

    [SerializeField] private Button addFormButton;

    private List<GameObject> forms;

    private void OnEnable()
    {
        FormController.OnNewForm += AddNewForm;
    }

    private void OnDisable()
    {
        FormController.OnNewForm -= AddNewForm;
    }

    void AddNewForm()
    {
        Instantiate(formPrefab, formsParent);
    }
}