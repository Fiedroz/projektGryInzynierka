using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.Rendering.DebugUI;

public class CameraController : MonoBehaviour
{
    [SerializeField] float lerpDuration;
    [SerializeField] Vector3[] cameraAngles;
    [SerializeField] Vector3[] cameraPositions;
    [SerializeField] GameObject[] panels;
    public int index;
    void Start()
    {
        index = 2;
        lerpDuration = 3f;
        StartCoroutine("moveCamera");
        //TODO zastanowiæ siê nad zastosowaniem StartCoroutine
    }
    void Update()
    {

    }
    private IEnumerator moveCamera()
    {
        while(true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(cameraAngles[index]), lerpDuration * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, cameraPositions[index], lerpDuration * Time.deltaTime);
            yield return null;
        }
    }
    public void SetFocusedPanel(GameObject panel)
    {
        if(panel != null)
        {
            int pos = Array.IndexOf(panels, panel);
            if (pos > -1)
            {
                index = pos;
            }
        }
    }

}
