using UnityEngine;

public class UIScale : MonoBehaviour
{
    public float minAspectRatio; // Aspect ratio límite
    public Vector3 minPosition;  
    public Vector3 minRotation;
    public float mediumAspectRatio; // Aspect ratio límite
    public Vector3 mediumPosition;
    public Vector3 mediumRotation;
    public Vector3 maxPosition;
    public Vector3 maxRotation;



    public Camera mainCamera;
    private void Update()
    {
        float currentAspectRatio = (float)Screen.width / Screen.height;
        if (currentAspectRatio > minAspectRatio)
        {
            minCameraPosition();
        }
        else if (currentAspectRatio > mediumAspectRatio)
        {
            mediumCameraPosition();
        }
        else if (currentAspectRatio < mediumAspectRatio)
        {
            maxCameraPosition();
        }
    }

    private void minCameraPosition()
    {
        mainCamera.transform.position = minPosition;
        mainCamera.transform.rotation = Quaternion.Euler(minRotation);
    }

    private void mediumCameraPosition()
    {
        mainCamera.transform.position = mediumPosition;
        mainCamera.transform.rotation = Quaternion.Euler(mediumRotation);
    }

    private void maxCameraPosition()
    {
        mainCamera.transform.position = maxPosition;
        mainCamera.transform.rotation = Quaternion.Euler(maxRotation);
    }
}
