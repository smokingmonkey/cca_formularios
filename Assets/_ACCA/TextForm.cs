using TMPro;
using UnityEngine;

public class TextForm : AbstractFormItem
{
    [SerializeField] public TMP_InputField tittle;
    [SerializeField] public TMP_InputField content;

    
    public TextData GetData()
    {
        return new TextData(orderInFormulary, tittle.text, content.text);
    }
}
