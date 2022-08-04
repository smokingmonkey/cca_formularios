using TMPro;
using UnityEngine;

public class TextForm : AbstractFormItem
{
    [SerializeField] private TMP_InputField content;

    public TextData GetData()
    {
        return new TextData(orderInFormulary, name, content.text);
    }
}
