using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float rayHeight; // Altura del raycast
    public float rayLength; // Longitud del raycast
    public EnemyMover mov;
    public string objectTag;
    public string limitTag;
    private bool twopaths;
    private bool twoblock;
    private bool collision;
    public GameObject terrain;
    private GameObject saveterrain;
    void FixedUpdate()
    {
        if(mov.directionMove.x == 1)
        {
            Cast(Vector3.right, "derecha");
        }
        else if(mov.directionMove.x == -1)
        {
            Cast(Vector3.left, "izquierda");
        }
        else if(mov.directionMove.z == -1)
        {
            Cast(Vector3.back, "detras");
        }
        if(collision)
        {
            if(terrain.tag == "Vacio" && Mathf.Cos(Mathf.Round(mov.model.transform.rotation.eulerAngles.y) * Mathf.Deg2Rad)*-1 == -1)
            {
                collision = false;
                mov.stop = false;
                mov.restartmov();

            }
        }
    }

    void Cast(Vector3 direction, string name)
    {
        Ray ray = new Ray(transform.position + new Vector3(0, rayHeight, 0), transform.TransformDirection(direction));
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            
            if (hit.collider.CompareTag(objectTag) || hit.collider.CompareTag(limitTag))
            {
                if(direction == mov.directionMove)
                {
                    mov.speed = 0f;
                    mov.directionMove= new Vector3(0f, 0f, 0f);
                    if (name == "detras")
                    {
                        saveterrain=hit.collider.gameObject;
                        if(transform.position.z <=0.5)
                        {
                            Cast(Vector3.right, "derecha");
                            Cast(Vector3.left, "izquierda");
                            twoblock=false;
                            twopaths=false;
                        }
                        else
                        {
                            mov.stop=true;
                            terrain=saveterrain;
                            collision=true;
                            mov.collision=true;
                        }
                    }
                    else
                    { 
                        Cast(Vector3.back, "detras");
                    }
                }
                else if(name == "detras")
                {
                    mov.detectedRotated = true;
                    mov.rotationSpeed = Mathf.Sin(Mathf.Round(mov.model.transform.rotation.eulerAngles.y) * Mathf.Deg2Rad)*-1;
                    mov.stop=true;
                    terrain=hit.collider.gameObject;
                    collision=true;
                }
                else if(name == "derecha")
                {
                    twoblock=true;
                    
                }
                else if(name == "izquierda" && twoblock)
                {
                    mov.stop=true;
                    terrain=saveterrain;
                    mov.collision=true;
                    twoblock=false;
                    collision=true;
                }
            }
            else if ( mov.directionMove == new Vector3(0f, 0f, 0f))
            {
                if (name == "derecha" || name == "izquierda")
                {
                    mov.detectedRotated = true;
                    mov.rotationSpeed = direction.x * -1;
                    if(twopaths)
                    {
                        mov.rotationSpeed = (Random.Range(0, 2) * 2) - 1;
                        twopaths = false;
                    }
                    else
                    {
                        twopaths = true;
                    }
                }
                else
                {
                    mov.detectedRotated = true;
                    mov.rotationSpeed = Mathf.Sin(Mathf.Round(mov.model.transform.rotation.eulerAngles.y) * Mathf.Deg2Rad)*-1;
                }
            }
        }
        else if ( mov.directionMove == new Vector3(0f, 0f, 0f))
        {
            
            if (name == "derecha" || name == "izquierda")
            {
                mov.detectedRotated = true;
                mov.rotationSpeed = direction.x * -1;
                if(twopaths)
                {
                    mov.rotationSpeed = (Random.Range(0, 2) * 2) - 1;
                    twopaths = false;
                }
                else
                {
                    twopaths = true;
                }
            }
            else
            {
                
                mov.detectedRotated = true;
                mov.rotationSpeed = Mathf.Sin(Mathf.Round(mov.model.transform.rotation.eulerAngles.y) * Mathf.Deg2Rad)*-1;
            }
        }
    }

}


