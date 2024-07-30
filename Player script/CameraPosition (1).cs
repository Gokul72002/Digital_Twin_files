using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{

    public Transform CamPosition;

    void Start()
    {
        
    }


    void Update()
    {
        transform.position = CamPosition.position;
    }
}
