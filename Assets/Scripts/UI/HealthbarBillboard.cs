using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarBillboard : MonoBehaviour
{
    public Transform cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
