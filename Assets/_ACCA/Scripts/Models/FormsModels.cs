using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace _ACCA.Scripts.Models
{
    [Serializable]
    public class FormData
    {
        public string userId;
        public string tittle;
        public string uniqueIdentifier;
        public List<TextData> textDataList;
        //public List<ImageData> textDataList;

        public FormData(string userId, string tittle,string uniqueIdentifier, List<TextData> textDataList)
        {
            this.userId = userId;
            this.tittle = tittle;
            this.uniqueIdentifier = uniqueIdentifier;
            this.textDataList = textDataList;
        }
    }


    [Serializable]
    public class TextData
    {
        public int orderInFormulary;
        public string tittle;
        public string content;

        public TextData(int orderInFormulary, string tittle,  string content)
        {
            this.orderInFormulary = orderInFormulary;
            this.tittle = tittle;
            this.content = content;
        }
    }
}