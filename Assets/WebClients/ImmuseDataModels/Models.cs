using System;
using UnityEngine;

namespace WebClients.ImmuseDataModels
{
    [Serializable]
    public class UploadScreenshotData
    {
        public string file;

        public string fileName;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }


    [Serializable]
    public class UploadScreenshotResponseData
    {
        public string imageUri;

        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }

    [Serializable]
    public class UploadRemixNftData
    {
        public string owner;
        public string name;
        public string description;
        public string image;
        public string attributes;
        public string remixSliderData;

        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
    
    [Serializable]
    public class GetRemixByWalletData
    {
        public string wallet;
        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
    
    [Serializable]
    public class GetRemixByWalletDataResponsePayload
    {
        public string _id;
        public string createAt;
        public string owner;
        public int internalCode;
        public string tokenUri;
        public string tokenImage;
        public bool isMinted ;
        public bool wasTransferred ;
        public int __v;
        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
    
    [Serializable]
    public class GetRemixByWalletDataResponse
    {
        public string owner;
        public GetRemixByWalletDataResponsePayload [] payload;
        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
}