using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingClick : MonoBehaviour
{

    public float minCollideRadius;
    public float maxCollideRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float distance = Vector3.Distance(collision.transform.position, transform.position);

        if (distance >= minCollideRadius && distance <= maxCollideRadius)
        {
            Debug.Log("the ring has been clicked!");
        }
    }
}
