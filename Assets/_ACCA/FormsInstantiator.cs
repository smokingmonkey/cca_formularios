using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormsInstantiator : MonoBehaviour
{
    public static FormsInstantiator Instance;

    [SerializeField] private GameObject formularyPrefab;

    [SerializeField] private GameObject parent;

    private void Awake()
    {
        Instance = this;
    }


    public void OpenForm(FormData formData)
    {
        UiReferences.Instance.OpenVisualizerPanel();
        
        foreach (var item in formData.textDataList)
        {
            GameObject newForm = Instantiate(formularyPrefab, parent.transform);

            var controller = newForm.GetComponent<FormInstancerController>();

            controller.NewTextForm(item.tittle, item.content);
        }
        
        
    }
}