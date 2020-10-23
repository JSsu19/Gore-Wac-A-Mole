using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform objectToMove;
    public Transform target;
    Camera cam;
    void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);

        objectToMove.position = target.position;
    }
}