using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrascMonsterAI : MonoBehaviour
{

    public GameObject monsterObject;
    public float maxAngle;
    public float maxRadius;
    private bool isInFov = false;
    public GameObject player;
    private NavMeshAgent fish;

     void Start()
    {
        

    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        if (!isInFov)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;

        Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * maxRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);


    }

    public static bool inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {

        Collider[] overlaps = new Collider[10];
        int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);

        for (int i = 0; i < count + 1; i++)
        {

            if (overlaps[i] != null)
            {

                if (overlaps[i].transform == target)
                {

                    Vector3 directionBetween = (target.position - checkingObject.position).normalized;
                    directionBetween.y *= 0;

                    float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                    if (angle <= maxAngle)
                    {

                        Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit, maxRadius))
                        {

                            if (hit.transform == target)
                                return true;

                        }


                    }


                }

            }

        }

        return false;
    }

    private void Update()
    {
        isInFov = inFOV(transform, player.transform, maxAngle, maxRadius);
        if (isInFov == true)
        {
            Debug.Log("I can see you");
            Vector3 rotateDirection = player.transform.position - monsterObject.transform.position;
            Vector3 rotateNewDirection = Vector3.RotateTowards(monsterObject.transform.forward, rotateDirection, 5.0f, 0.0f);

            monsterObject.transform.position = Vector3.MoveTowards(monsterObject.transform.position, player.transform.position, Time.deltaTime * 11f);
            monsterObject.transform.rotation = Quaternion.LookRotation(rotateNewDirection);
        }

        else
        {
            Debug.Log("nah");
        }
    }

    
    void OnTriggerEnter(Collider col)
    {
    /*
        if (col.gameObject.name == "outer windscreen")
        {
            Debug.Log("Here in here enter");

            Vector3 rotateDirection = col.transform.position - monsterObject.transform.position;
            Vector3 rotateNewDirection = Vector3.RotateTowards(monsterObject.transform.forward, rotateDirection, 5.0f, 0.0f);

            monsterObject.transform.position = Vector3.MoveTowards(monsterObject.transform.position, col.transform.position, Time.deltaTime * 11f);
            monsterObject.transform.rotation = Quaternion.LookRotation(rotateNewDirection);

        }*/
         if (col.CompareTag("flare"))
        {
            Vector3 rotateDirection = col.transform.position + monsterObject.transform.position;
            Vector3 rotateNewDirection = Vector3.RotateTowards(monsterObject.transform.forward, rotateDirection, 5.0f, 0.0f);

            monsterObject.transform.position = -Vector3.MoveTowards(monsterObject.transform.position, col.transform.position, Time.deltaTime * 11f);
            monsterObject.transform.rotation = Quaternion.LookRotation(rotateNewDirection);
        }
    }

  
    }



