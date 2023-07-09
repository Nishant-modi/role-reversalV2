using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCheck : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Rigidbody2D rb1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("" + rb1.sharedMaterial.bounciness);
    }
}
