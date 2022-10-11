using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lupaclick : MonoBehaviour
{
    private Camera control_cam;
    [SerializeField] private float step;
    [SerializeField] private float max, min;
    private Animator aux;

    private bool zoom = false;
    void Start()
    {
        control_cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent <Camera>();
        control_cam.orthographicSize = min;
        aux = GetComponent<Animator>();
    }

    private void Update()
    {
        if (zoom)
        {
            control_cam.orthographicSize -= step;
            if(control_cam.orthographicSize <= max)
            {
                control_cam.orthographicSize = max;
                zoom = false;
            }
        }


    }

    public void clicked_btn()
    {
        zoom = true;
        aux.SetTrigger("Deappear");
    }

    public void appear()
    {
        aux.SetTrigger("Appear");
    }
}
