using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavingDataService : MonoBehaviour
{
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
        var uniqueIdentifier = "000";
        //var uniqueIdentifier = formDataManager.UniqueIdentifier;
        var data = formDataManager.GetDataSerialized();

        Debug.LogError("Saving data " +   data);

        PlayerPrefs.SetString(uniqueIdentifier, data);

        GetLocalData();
    }

    public string GetLocalData()
    {

        var playerData = PlayerPrefs.GetString("000");
        
        FormData deserializedFormData = JsonUtility.FromJson<FormData>(playerData);
      
        Debug.LogError(deserializedFormData.userId + deserializedFormData.textDataList[0].content);
        
        Debug.LogError("Getting local data" + playerData);
        return playerData;
    }
}