using System;
using System.Collections.Generic;
using _ACCA.Scripts.Managers;
using _ACCA.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

public class OpenFormButton : MonoBehaviour
{
    public FormData formData;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener
        (() =>
            {
                OpenFormsManager.Instance.OpenForm(formData);
            }
        );
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
}