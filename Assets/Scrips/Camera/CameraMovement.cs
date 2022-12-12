using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public Vector2 maxPoint;

    public Vector2 minPoint;

    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPostion = new Vector3(target.position.x, target.position.y, transform.position.z);



            targetPostion.x = Mathf.Clamp(targetPostion.x, minPoint.x, maxPoint.x);

            targetPostion.y = Mathf.Clamp(targetPostion.y, minPoint.y, maxPoint.y);



            transform.position = Vector3.Lerp(transform.position, targetPostion, smoothing);
        }    
    }
}
