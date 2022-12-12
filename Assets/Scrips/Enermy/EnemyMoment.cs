using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class EnemyMoment : MonoBehaviour
{

    ////ENEMY FIND PLAYER
    NavMeshAgent agent;
    Vector3 DestinationPoint;

    public Transform target;


    // Start is called before the first frame update
    void Start()
    {

        agent = this.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {
        agent.ResetPath();
        DestinationPoint = new Vector3(target.position.x, target.position.y, transform.position.z);
        agent.SetDestination(DestinationPoint);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject)
        {

        }    
    }

}
