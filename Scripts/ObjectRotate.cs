using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{


    public float speed = 20;
    public float lerpSpeed = 5;
    private float xDeg;
    private float offset;

    private Quaternion fromRotation;
    private Quaternion toRotation;


    private void Start()
    {
        offset = transform.eulerAngles.y;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            xDeg -= Input.GetAxis("Mouse X") * speed;
            fromRotation = transform.rotation;
            toRotation = Quaternion.Euler(5, xDeg + offset, 0);
            transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);
        }
    }
}