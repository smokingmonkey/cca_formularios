using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenFormsInstantiator : MonoBehaviour
{
    public static OpenFormsInstantiator Instance;

    [SerializeField] private TMP_Text tittle;

    [SerializeField] private GameObject formularyPrefab;

    [SerializeField] private GameObject parent;

    private void Awake()
    {
        Instance = this;
    }


    public void OpenForm(FormData formData)
    {
        UiReferences.Instance.OpenVisualizerPanel();

        tittle.text = formData.tittle;
        
        foreach (var item in formData.textDataList)
        {
            GameObject newForm = Instantiate(formularyPrefab, parent.transform);

            var controller = newForm.GetComponent<FormInstancerController>();

            controller.NewTextForm(item.tittle, item.content);
        }
        
        
    }
}