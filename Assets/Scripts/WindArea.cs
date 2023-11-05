using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public float strength;
    public Vector2 direction;
    public CharacterController cc;

    [SerializeField] private GameObject rw;
    [SerializeField] private GameObject lw;

    public void Update()
    {

        if(strength>13)
        {
            cc.isItWindy = true;
            if (direction.x < 0)
            {
                lw.SetActive(true);
                rw.SetActive(false);
            }
            else if (direction.x >= 0)
            {
                rw.SetActive(true);
                lw.SetActive(false);
            }
        }    
        else
        {
            cc.isItWindy = false;
            rw.SetActive(false);
            lw.SetActive(false);
        }
    }
}
