using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Webcam : MonoBehaviour
{
    private WebCamDevice _device = new WebCamDevice();

    private RawImage _rawImage;
    private WebCamTexture _webCamTexture;

    private Camera _camera = null;
    private RectTransform _rectTransform = null;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
        _rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        StartWebCam();

        Debug.Log(_rectTransform.sizeDelta);
        Debug.Log(_camera.aspect);
    }

    public void StartWebCam()
    {
        _rawImage = GetComponentInChildren<RawImage>();
        _webCamTexture = new WebCamTexture();
        _rawImage.material.mainTexture = _webCamTexture;
        _webCamTexture.Play();
    }

    public void StopWebCam()
    {
        _webCamTexture.Stop();
    }
}
