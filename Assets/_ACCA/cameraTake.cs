using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class cameraTake : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.RawImage _rawImage;

    [SerializeField] private Button takePicture;


    private WebCamTexture tex;

    private void OnEnable()
    {
        takePicture.onClick.AddListener(TakePicture);
    }

    private void OnDisable()
    {
        takePicture.onClick.RemoveListener(TakePicture);
    }

    private void TakePicture()
    {
        tex.Stop();
        takePicture.gameObject.SetActive(false);

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
