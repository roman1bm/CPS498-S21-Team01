using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform submarine;
    int movementSpeed = 4;
    int minDistance = 5;
    int maxDistance = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(submarine);

        if(Vector3.Distance(transform.position, submarine.position) >= minDistance)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, submarine.position) <= maxDistance)
        {
            
        }

    }
}
