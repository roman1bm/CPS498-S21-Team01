using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilfishMonsterAI : MonoBehaviour
{

    //public GameObject monsterObject;
    private Vector3 rotateDirection;
    private Vector3 rotateNewDirection;

    public Transform target = null;

    private bool debug = true;


    private void changeTarget(Transform newTarget)
    {
        target = newTarget;
        if (debug) print("switching targets!");
    }
    public void loseTarget()
    {
        target = null;
        if(debug) print("Lost target!");
    }

    private void FixedUpdate()
    {
        if (target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 16f);
            rotateDirection = target.position - transform.position;
            rotateNewDirection = Vector3.RotateTowards(transform.forward, rotateDirection, 16f, 0.0f);
            transform.rotation = Quaternion.LookRotation(rotateNewDirection);
        }
        //else loseTarget();
    }

    void OnTriggerEnter(Collider col)
    {
        if (debug) print("OnEnter: " + col.gameObject.tag);

        //update chase target
        if (col.gameObject.CompareTag("flare")) {
            changeTarget(col.transform);
            col.transform.GetComponent<flarebullet>().beingTargeted(transform.gameObject);
        }
            
        else if (col.gameObject.name == "outer windscreen")
            changeTarget(col.transform);
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.transform == target)
            loseTarget();
    }
}
