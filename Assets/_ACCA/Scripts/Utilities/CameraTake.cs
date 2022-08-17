using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraTake : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.RawImage _rawImage;

    
    private WebCamTexture tex;

   
    public Texture TakePicture()
    {
        tex.Stop();
        return _rawImage.texture;
    }


    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        // for debugging purposes, prints available devices to the console
        for (int i = 0; i < devices.Length; i++)
        {
            print("Webcam available: " + devices[i].name);
        }

        //Renderer rend = this.GetComponentInChildren<Renderer>();

        // assuming the first available WebCam is desired

        tex = new WebCamTexture(devices[0].name);
        //rend.material.mainTexture = tex;
        this._rawImage.texture = tex;
        tex.Play();
    }
}
