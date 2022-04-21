using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TouchInput : MonoBehaviour
{

    [SerializeField] private TMP_Text _spot1 = null;
    [SerializeField] private TMP_Text _spot2 = null;
    [SerializeField] private TMP_Text _spot3 = null;
    [SerializeField] private TMP_Text _spot4 = null;

    private RaycastHit _hit;
    private Ray _ray;

    private Webcam _webcam;

    private void Start()
    {
        _webcam = Camera.main.gameObject.GetComponent<Webcam>();
    }

    private void Update()
    {
        DrawBow();
    }

    private void DrawBow()
    {
        if (Input.touchSupported)
        {
            _spot1.text = "Touch is Supported";
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _spot2.text = touch.position.ToString();

                    _ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0f));

                    if (Physics.Raycast(_ray, out _hit))
                    {
                        _spot3.text = _hit.collider.name;

                        var bow = _hit.collider.gameObject.GetComponent<BowController>();
                        if (bow != null)
                        {
                            _spot4.text = "Bow is not Null";
                            bow.gameObject.GetComponent<Animator>().SetTrigger("draw");
                        }
                        else
                        {
                            _spot4.text = "Bow is Null";
                        }
                    }

                }

                if (touch.phase == TouchPhase.Moved)
                {
                    var bow = _hit.collider.gameObject.GetComponent<BowController>();
                    if (bow != null)
                    {
                        //var pivot = bow.gameObject.transform.parent;
                        var pivot = _webcam.transform;
                        pivot.LookAt(Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,10f)));
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    var bow = _hit.collider.gameObject.GetComponent<BowController>();
                    if (bow != null)
                    {
                        bow.gameObject.GetComponent<Animator>().SetTrigger("shoot");
                    }
                    _spot4.text = "";
                    _hit = new RaycastHit();

                }
            }
        }
        else
        {
            _spot1.text = "Touch is not Supported";
            if (Input.GetMouseButtonDown(0))
            {
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition); ;
                
                if (Physics.Raycast(_ray,out _hit))
                {
                    _spot2.text = _hit.collider.name; 
                    var bow = _hit.collider.gameObject.GetComponent<BowController>();
                    if (bow != null)
                    {
                        bow.gameObject.GetComponent<Animator>().SetTrigger("draw");
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                var bow = _hit.collider.gameObject.GetComponent<BowController>();
                if (bow != null) bow.gameObject.GetComponent<Animator>().SetTrigger("shoot");
            }
        }
    }
}
