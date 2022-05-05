using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Webcam : MonoBehaviour
{
    private WebCamDevice _device = new WebCamDevice();
    public WebCamDevice Device => _device;

    private RawImage _rawImage;
    private WebCamTexture _webCamTexture;
    private Quaternion _baseRotation;
    private Gyroscope _camGyro;

    [SerializeField] private RectTransform _canvasTransform = null;

    private Vector3 _dir = Vector3.zero;
    private Quaternion _offset;

    private void Awake()
    {
        _camGyro = Input.gyro;
        _camGyro.enabled = true;
    }

    private void Start()
    {
        _rawImage = GetComponentInChildren<RawImage>();
        _webCamTexture = new WebCamTexture();
        _rawImage.material.mainTexture = _webCamTexture;
        _baseRotation = transform.rotation;
        StartWebCam();

        _offset = transform.rotation * Quaternion.Inverse(GyroToUnity(_camGyro.attitude));
    }

    private void Update()
    {
        CameraGyroscopeRotation();
    }

    public void StartWebCam()
    {
        _webCamTexture.Play();
    }

    public void StopWebCam()
    {
        _webCamTexture.Stop();
    }

    public void CameraGyroscopeRotation()
    {
        transform.rotation = _offset * GyroToUnity(_camGyro.attitude);
        _canvasTransform.rotation = _offset * GyroToUnity(_camGyro.attitude);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    private void OnDisable()
    {
        StopWebCam();
    }
}
