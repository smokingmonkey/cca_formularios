using System;
using UnityEngine;
using UnityEngine.UI;

public class OpenForm : MonoBehaviour
{
    public FormData formData;
    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener
        (() =>
            {
                FormsInstantiator.Instance.OpenForm(formData);
            }
        );
    }

  

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
}