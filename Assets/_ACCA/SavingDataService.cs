using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SavingDataService : MonoBehaviour
{
    public const string lastIndentifier = "keysList";
    //private List<string> keysList;


    [SerializeField] private Button save;
    [SerializeField] private Button clear;

    [SerializeField] private FormDataManager formDataManager;

    private void OnEnable()
    {
        save.onClick.AddListener(SaveDataLocally);
    }

    private void OnDisable()
    {
        save.onClick.RemoveListener(SaveDataLocally);
    }

    private void SaveDataLocally()
    {
        int uniqueIdentifier = GetNewUniqueIdentifier();

        formDataManager.RegisterNewForm(uniqueIdentifier);
        
        var data = formDataManager.GetDataSerialized();

        Debug.LogError("Saving data " + data.json);  

        PlayerPrefs.SetString(uniqueIdentifier.ToString(), data.json);
        
        PlayerPrefs.Save();

        //GetLocalData();
    }


   

    public static FormData GetLocalDataByKey(string key)
    {
        var playerData = PlayerPrefs.GetString(key);

        //var j = JsonUtility.ToJson(playerData);

        FormData deserializedFormData = JsonUtility.FromJson<FormData>(playerData);
      
//        Debug.LogError(deserializedFormData.uniqueIdentifier + deserializedFormData.textDataList[0].content);
        
        Debug.LogError(playerData  + "****************");

        // Debug.LogError(deserializedFormData.userId + deserializedFormData.textDataList[0].content);
        //
        // Debug.LogError("Getting local data" + playerData);
        return deserializedFormData;
    }

    static int GetNewUniqueIdentifier()
    {

        if (PlayerPrefs.HasKey(lastIndentifier))
        {
            var  last =PlayerPrefs.GetInt(lastIndentifier);
            
            PlayerPrefs.SetInt(lastIndentifier, last + 1);
            return last + 1;
        }
        PlayerPrefs.SetInt(lastIndentifier, 0);
        return 0;
    }
    
    public static string GetLastUniqueIdentifier()
    {

        if (PlayerPrefs.HasKey(lastIndentifier))
        {
           
            return PlayerPrefs.GetInt(lastIndentifier).ToString();
        }
        
        return null;
    }
}