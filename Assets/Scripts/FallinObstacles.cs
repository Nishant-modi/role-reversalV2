using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallinObstacles : MonoBehaviour
{
    // Start is called before the first frame update

    public float gravityLimit;
    public Rigidbody2D rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.gravity.y < gravityLimit)
        {
            rb.isKinematic = false;
        }
    }
}
