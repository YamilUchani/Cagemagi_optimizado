using UnityEngine;

public class UIScale : MonoBehaviour
{
    public float minAspectRatio; // Aspect ratio límite
    public Vector3 minPosition;  
    public float minCameraSize;
    public Vector3 maxPosition;
    public float maxCameraSize;
    public Camera mainCamera;
    private void Update()
    {
        float currentAspectRatio = (float)Screen.width / Screen.height;

        if (currentAspectRatio < minAspectRatio)
        {
            minCameraPosition();
        }
        else
        {
            maxCameraPosition();
        }
    }

    private void minCameraPosition()
    {
        mainCamera.transform.position = minPosition;
        mainCamera.orthographicSize = minCameraSize;
    }

    private void maxCameraPosition()
    {
        mainCamera.transform.position = maxPosition;
        mainCamera.orthographicSize = maxCameraSize;
    }
}
