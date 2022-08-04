using System;
using System.Collections.Generic;
using System.Security.Cryptography;


[Serializable]
public class FormData
{
    public string userId;
    public string uniqueIdentifier;
    public List<TextData> textDataList;
    //public List<ImageData> textDataList;

    public FormData(string userId, string uniqueIdentifier, List<TextData> textDataList)
    {
        this.userId = userId;
        this.uniqueIdentifier = uniqueIdentifier;
        this.textDataList = textDataList;
    }
}


[Serializable]
public class TextData
{
    public int orderInFormulary;
    public string name;
    public string content;

    public TextData(int orderInFormulary, string name,  string content)
    {
        this.orderInFormulary = orderInFormulary;
        this.name = name;
        this.content = content;
    }
}