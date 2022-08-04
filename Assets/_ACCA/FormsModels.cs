using System;
using System.Collections.Generic;


[Serializable]
public class FormData
{
    public string userId;
    public int index;
    public List<TextData> textDataList;

    public FormData(string userId, int index, List<TextData> textDataList)
    {
        this.userId = userId;
        this.index = index;
        this.textDataList = textDataList;
    }
}


[Serializable]
public class TextData
{
    public string content;

    public TextData(string contentText)
    {
        content = contentText;
    }
}