using System;
using System.Collections.Generic;
using _ACCA.Scripts.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavedFormsInstantiator : MonoBehaviour
{
    [SerializeField] private Button update;

    [SerializeField] private Button formPrefab;
    [SerializeField] private GameObject savedFormsButtonsParent;

    private int lastAmountOfForms;


    private void Start()
    {
    }

    private void OnEnable()
    {
        update.onClick.AddListener(FillData);
        FillData();
    }

    private void OnDisable()
    {
        update.onClick.RemoveListener(FillData);
    }

    private void FillData()
    {
        List<FormData> forms = new List<FormData>();
        int lastIdentifier;

        var dataToParse = SavingDataService.GetLastUniqueIdentifier();
        if (dataToParse != null)
        {


            lastIdentifier = int.Parse(dataToParse);
            var upperLimit = lastIdentifier + 1;

            for (int i = lastAmountOfForms; i < upperLimit; i++)
            {
                var data = SavingDataService.GetLocalDataByKey(i.ToString());
                forms.Add(data);
                lastAmountOfForms++;
            }

            foreach (var item in forms)
            {
                var newButton = Instantiate(formPrefab, savedFormsButtonsParent.transform);

                newButton.GetComponentInChildren<TMP_Text>().text = item.tittle;

                newButton.GetComponent<OpenFormButton>().formData = item;
            }
        }
       
    }
}