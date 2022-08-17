using _ACCA.Scripts.Models;
using TMPro;
using UnityEngine;

namespace _ACCA.Scripts.Controllers.FormItems
{
    public class TextForm : AbstractFormItem
    {
        [SerializeField] public TMP_InputField tittle;
        [SerializeField] public TMP_InputField content;

    
        public TextData GetData()
        {
            return new TextData(orderInFormulary, tittle.text, content.text);
        }
    }
}
