using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FormDataController : MonoBehaviour
{
    private int id;

    [SerializeField] private TMP_InputField tittle;

    [SerializeField] private List<TextForm> textForm;

    [SerializeField] private List<ImageForm> imageForm;

    private void Start()
    {
        // textForm.Add(new TextForm());
        // textForm.Add(new TextForm());
        //
        // GetDataSerialized("xxx", 100);
    }

    public string GetDataSerialized(string userId, int id)
    {
        List<TextData> textFormData = new List<TextData>();

        foreach (var item in textForm)
        {
            textFormData.Add(item.GetData());
        }

        FormData formData = new FormData(userId, id, textFormData);
        var da = formData.Serialize();


        return formData.Serialize().json;
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