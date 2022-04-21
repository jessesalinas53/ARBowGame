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
    private Camera _camera;

    [SerializeField] private TMP_Text _spot1 = null;
    [SerializeField] private TMP_Text _spot2 = null;
    [SerializeField] private TMP_Text _spot3 = null;
    [SerializeField] private TMP_Text _spot4 = null;
    [SerializeField] private RectTransform _canvasTransform = null;

    private Vector3 _dir = Vector3.zero;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        _rawImage = GetComponentInChildren<RawImage>();
        _webCamTexture = new WebCamTexture();
        _rawImage.material.mainTexture = _webCamTexture;
        _baseRotation = transform.rotation;
        StartWebCam();
    }

    private void Update()
    {
        _canvasTransform.rotation = Quaternion.Euler(0,0,-_webCamTexture.videoRotationAngle) * _camera.gameObject.transform.rotation;
        //AccelerationToRotation(10f);
    }

    public void StartWebCam()
    {
        _webCamTexture.Play();
    }

    public void StopWebCam()
    {
        _webCamTexture.Stop();
    }

    private void CheckOrientation()
    {
        if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            _canvasTransform.sizeDelta = new Vector2(1920, 2160);
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            _canvasTransform.sizeDelta = new Vector2(3840, 2160);
        }
    }

    private void AccelerationToRotation(float speed)
    {
        _dir.x = Input.acceleration.x;
        _dir.y = Input.acceleration.y;
        _dir.z = Input.acceleration.z;

        if (_dir.sqrMagnitude > 1) _dir.Normalize();

        _dir *= Time.deltaTime;

        transform.rotation *= Quaternion.Euler(_dir * speed);
    }
}
