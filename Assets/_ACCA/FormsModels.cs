using System;


[Serializable]
public class FormData
{
    public string userId;
    public int index;
    public TextData textData;

    public FormData(string userId, int index, TextData textData)
    {
        this.userId = userId;
        this.index = index;
        this.textData = textData;
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


