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
    //private Camera _camera;
    private Gyroscope _camGyro;

    [SerializeField] private TMP_Text _spot1 = null;
    [SerializeField] private TMP_Text _spot2 = null;
    [SerializeField] private TMP_Text _spot3 = null;
    [SerializeField] private TMP_Text _spot4 = null;
    [SerializeField] private RectTransform _canvasTransform = null;

    private Vector3 _dir = Vector3.zero;

    private void Awake()
    {
        //_camera = GetComponent<Camera>();
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
    }

    private void Update()
    {
        CameraGyroscopeRotation();

        _spot1.text = _camGyro.attitude.eulerAngles.ToString();
        //_spot2.text = _camGyro.attitude.ToString();
        //_spot3.text = _camGyro.rotationRateUnbiased.ToString();
        //_spot4.text = _camGyro.userAcceleration.ToString();
    }

    public void StartWebCam()
    {
        _webCamTexture.Play();
        Debug.Log("Started Webcam");
    }

    public void StopWebCam()
    {
        _webCamTexture.Stop();
    }

    public void CameraGyroscopeRotation()
    {
        gameObject.transform.rotation = _camGyro.attitude;
        _spot2.text = _canvasTransform.rotation.ToString();
        //_canvasTransform.rotation = Quaternion.Euler(0, 0, -_webCamTexture.videoRotationAngle) * gameObject.transform.rotation;
    }
}
