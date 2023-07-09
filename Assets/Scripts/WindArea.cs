using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public float strength;
    public Vector2 direction;

    [SerializeField] private GameObject rw;
    [SerializeField] private GameObject lw;

    public void Update()
    {
        if(direction.x < 0 && strength >1)
        {
           lw.SetActive(true);
           rw.SetActive(false);
        }
        else if(direction.x>=0 && strength>1)
        {
            rw.SetActive(true);
            lw.SetActive(false);
        }
        else
        {
            rw.SetActive(false);
            lw.SetActive(false);
        }
    }
}
