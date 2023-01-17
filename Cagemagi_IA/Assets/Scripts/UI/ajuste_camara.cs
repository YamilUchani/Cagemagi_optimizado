using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ajuste_camara : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;

    void Update()
    {
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        Vector3 cameraPosition = target.position + new Vector3(0, 0, -distance);
        cameraPosition.x = target.position.x;
        cameraPosition.y = target.position.y + distance * 0.5f / aspectRatio;
        transform.position = cameraPosition;
        transform.LookAt(target);
    }
}