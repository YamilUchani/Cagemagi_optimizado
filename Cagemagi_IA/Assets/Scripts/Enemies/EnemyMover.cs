using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed, destroyPosition, rotationSpeed, torque;
    public GameObject model;
    public bool detectedRotated;
    
    public Vector3 directionMove;
    private float speedReal, totalRotation, rotationAmount;
    public bool stop;
    public bool collision;
    
    private void Start()
    {
        directionMove = new Vector3(0f, 0f, -1f);
        speedReal = speed;
    }
    
    private void Update()
    {
        transform.position += directionMove * speed * Time.deltaTime;
        
        if (transform.position.z <= destroyPosition)
            Destroy(gameObject);
        
        if (detectedRotated)
        {
            speed=0;
            
            Rotate(rotationSpeed * torque);
        }
        if (speed == 0)
        {
            Vector3 roundedPosition = new Vector3(
                Mathf.RoundToInt(transform.position.x),
                transform.position.y,
                Mathf.RoundToInt(transform.position.z));
            transform.position = roundedPosition;
        }
    }
    
    public void Rotate(float rotationSpeed)
    {

        rotationAmount = rotationSpeed * Time.deltaTime;
        
        if (Mathf.Abs(totalRotation) + Mathf.Abs(rotationAmount) > 90f)
        {
            rotationAmount = Mathf.Sign(rotationAmount) * (90f - Mathf.Abs(totalRotation));
            totalRotation = Mathf.Sign(totalRotation) * 90f;
            detectedRotated = false;
        }
        else
        {
            totalRotation += rotationAmount;
            if(stop)
            {
                collision=true;
            }
        }
        
        model.transform.Rotate(0f, rotationAmount, 0f);
        
        if (!detectedRotated && !stop)
        {
            rotationAmount = 0f;
            rotationSpeed = 0f;
            totalRotation = 0f;
            model.transform.rotation = Quaternion.Euler(0f, Mathf.Round(model.transform.rotation.eulerAngles.y), 0f);
            speed = speedReal;
            float radians = Mathf.Round(model.transform.rotation.eulerAngles.y) * Mathf.Deg2Rad;
            directionMove = new Vector3(Mathf.Sin(radians), 0f, Mathf.Cos(radians)) * -1;
        }
    }
    public void restartmov()
    {
        rotationAmount = 0f;
        rotationSpeed = 0f;
        totalRotation = 0f;
        collision = false;
        detectedRotated = false;
        model.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        speed = speedReal;
        directionMove = new Vector3(0f, 0f, -1f);
    } 
}
