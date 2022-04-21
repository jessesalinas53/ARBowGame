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

    [SerializeField] private TMP_Text _debugRot = null;
    [SerializeField] private TMP_Text _debugAngle = null;
    [SerializeField] private TMP_Text _speedText = null;
    [SerializeField] private TMP_Text _gyroText = null;
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

        //_debugAngle.text = SystemInfo.supportsGyroscope.ToString();
    }

    private void Update()
    {
        //_debugAngle.text = _webCamTexture.videoRotationAngle.ToString();

        _canvasTransform.rotation = Quaternion.Euler(0,0,-_webCamTexture.videoRotationAngle) * _camera.gameObject.transform.rotation;
        //_debugRot.text = _canvasTransform.rotation.ToString();

        //CheckOrientation();
        AccelerationToRotation(10f);
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

        //_speedText.text = (_dir * speed).ToString();
        transform.rotation *= Quaternion.Euler(_dir * speed); 
        //_gyroText.text = transform.rotation.eulerAngles.ToString();
    }
}
