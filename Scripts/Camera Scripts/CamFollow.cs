﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float height = 0.0f;
    public float Distance;
    public bool smoothRotation;
    void Update()
    {
        Vector3 wantedPosition = target.TransformPoint(0, height, -Distance);
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * 2);
        if (smoothRotation)
        {
            Quaternion wantedRotation =
            Quaternion.LookRotation(target.position - transform.position, target.up);
            transform.rotation =
            Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * 10);
        }
        else
            transform.LookAt(target, target.up);
    }
}
