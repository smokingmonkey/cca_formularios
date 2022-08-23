using System.Collections.Generic;
using _ACCA.Scripts.Controllers.FormItems;
using _ACCA.Scripts.Models;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace _ACCA.Scripts.Managers
{
    public class FormDataManager : MonoBehaviour
    {
        [SerializeField]private TMP_InputField newFormtittle;

        private string userId;
        public string uniqueIdentifier;

        //[SerializeField] private TMP_InputField tittle;

        [SerializeField] private List<TextForm> textForms;

        [SerializeField] private List<ImageForm> imageForm;

        private void Start()
        {
            // textForm.Add(new TextForm());
            // textForm.Add(new TextForm());
            //
            // GetDataSerialized("xxx", 100);
        }


        public SerializationData GetDataSerialized()
        {
            List<TextData> textFormData = new List<TextData>();

            foreach (var item in textForms)
            {
                textFormData.Add(item.GetData());
            }

            FormData formData = new FormData(userId, newFormtittle.text, uniqueIdentifier, textFormData);

            return formData.Serialize();
        }

        public void RegisterNewForm(int identifier)
        {
            uniqueIdentifier = identifier.ToString();
        }


        public void RegisterNewTextForm(TextForm form)
        {
            //form.orderInFormulary = orderInFormulary;
            textForms.Add(form);
        }
    }
}


/*
 * FormData formData = new FormData("xx", id, textForm.GetData());

      var serializedFormData = formData.Serialize();
      
      Debug.LogError(serializedFormData.json);
      
      FormData deserializedFormData = JsonUtility.FromJson<FormData>(serializedFormData.json);
      
      Debug.LogError(deserializedFormData.userId + deserializedFormData.textData.content);
 *
 *
 * 
 */

// var dd = textForm.GetData().Serialize();
//
// Debug.LogError(dd.json);
//
//
// var ds = JsonUtility.FromJson<TextData>( dd.json);
//
// Debug.LogError(ds.content);
// var texForm = new JObject();
//
// var data = new JObject()
// {
//    ["user_id"] = "xxxxx",
//    ["index"] = index,
//    ["tittle"] = tittle.text
// };


/*
 *
 *
 *
 *   Debug.LogError(da.json);
        
        
        
        
        FormData deserializedFormData = JsonUtility.FromJson<FormData>(da.json);
      
        Debug.LogError(deserializedFormData.userId + deserializedFormData.textDataList[0].content);
        
 */