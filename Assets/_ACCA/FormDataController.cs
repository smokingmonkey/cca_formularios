using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FormDataController : MonoBehaviour
{
   private int index;
   
   [SerializeField] private TMP_InputField tittle;

   [SerializeField] private TextForm textForm;

   [SerializeField] private ImageForm imageForm;

   private void Start()
   {
      GetDataSerialized();
   }

   public string GetDataSerialized()
   {

      FormData formData = new FormData("xx", index, textForm.GetData());

      var serializedFormData = formData.Serialize();
      
      Debug.LogError(serializedFormData.json);
      
      FormData deserializedFormData = JsonUtility.FromJson<FormData>(serializedFormData.json);
      
      Debug.LogError(deserializedFormData.userId + deserializedFormData.textData.content);


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


      return "";
   }
   
}

