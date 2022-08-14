using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavedFormsInstantiator : MonoBehaviour
{
    [SerializeField] private Button update;

    [SerializeField] private Button formPrefab;
    [SerializeField] private GameObject savedFormsButtonsParent;


    private void Start()
    {
        FillData();
    }

    private void OnEnable()
    {
        update.onClick.AddListener(FillData);
    }

    private void OnDisable()
    {
        update.onClick.RemoveListener(FillData);
    }

    private void FillData()
    {
        List<FormData> forms = new List<FormData>();
        int lasIdentifier = int.Parse(SavingDataService.GetLastUniqueIdentifier());

        var upperLimit = lasIdentifier + 1;

        for (int i = 0; i < upperLimit; i++)
        {
            var data = SavingDataService.GetLocalDataByKey(i.ToString());
            forms.Add(data);
        }

        foreach (var item in forms)
        {
            var newButton = Instantiate(formPrefab, savedFormsButtonsParent.transform);

            newButton.GetComponentInChildren<TMP_Text>().text = item.tittle;

            newButton.GetComponent<OpenFormButton>().formData = item;
        }
    }
}