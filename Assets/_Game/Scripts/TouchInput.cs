using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TouchInput : MonoBehaviour
{
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
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0f));

                    if (Physics.Raycast(_ray, out _hit))
                    {
                        var bow = _hit.collider.gameObject.GetComponent<BowController>();
                        if (bow != null && bow.CanShoot) bow.gameObject.GetComponent<Animator>().SetTrigger("draw");
                    }

                }

                if (touch.phase == TouchPhase.Ended)
                {
                    var bow = _hit.collider.gameObject.GetComponent<BowController>();
                    if (bow != null && bow.CanShoot) bow.gameObject.GetComponent<Animator>().SetTrigger("shoot");
                    _hit = new RaycastHit();

                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition); ;
                
                if (Physics.Raycast(_ray,out _hit))
                {
                    var bow = _hit.collider.gameObject?.GetComponent<BowController>();
                    if (bow != null && bow.CanShoot)
                    {
                        bow.gameObject.GetComponent<Animator>().SetTrigger("draw");
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                var bow = _hit.collider.gameObject?.GetComponent<BowController>();
                if (bow != null && bow.CanShoot) bow.gameObject.GetComponent<Animator>().SetTrigger("shoot");
            }
        }
    }
}
