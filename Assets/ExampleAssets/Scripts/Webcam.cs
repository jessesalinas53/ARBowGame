using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Webcam : MonoBehaviour
{
    private WebCamDevice _device = new WebCamDevice();

    private RawImage _rawImage;
    private WebCamTexture _webCamTexture;

    void Start()
    {
        _rawImage = GetComponent<RawImage>();
        _webCamTexture = new WebCamTexture();
        _rawImage.material.mainTexture = _webCamTexture;
        _webCamTexture.Play();
    }
}
