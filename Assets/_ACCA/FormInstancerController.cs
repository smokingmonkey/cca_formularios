using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FormInstancerController : MonoBehaviour
{
    [SerializeField] private GameObject textForm;
    [SerializeField] private GameObject pictureForm;
    [SerializeField] private GameObject tableForm;
    
  public void NewTextForm(string tittle, string content)
    {
        textForm.SetActive(true);
      
        var tF = textForm.GetComponent<TextForm>();
        tF.tittle.text = tittle;
        tF.content.text = content;
    }
}