using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    Transform player;

    [SerializeField] float speed;

    [SerializeField] float pickUpDistance;

    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        
        if(distance < 0.1f)
        {
            Destroy(gameObject);
        }    
    }
}
