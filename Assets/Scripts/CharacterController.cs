using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jumpSpeed;
    public float fallGravityMultiplier;
    public float maxSpeed = 2;

    public bool jumpCheck;
    public bool dashCheck;

    public GameObject lostPanel;
    public GameObject winPanel;
    public Rigidbody2D rb;

    private bool obstacle;
    public bool isJumping;
    private bool isStopped;

    public bool inWindZone = false;
    public GameObject windZone;

    IEnumerator temp;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        isJumping = true;
        obstacle = false;
        temp = stoppedCheck();
        //StartCoroutine(temp);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        int rbPos = (int)rb.gravityScale;
        float direction = -Mathf.Sign(Physics2D.gravity.y);
        Move = 1f;

        //rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        rb.AddForce(new Vector2 (speed*Move, rb.velocity.y));
        if (jumpCheck && !isJumping && obstacle)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed * rbPos*direction), ForceMode2D.Impulse);
        }

           
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -2, maxSpeed),rb.velocity.y);
        }

        if (inWindZone)
        {
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
        }


    }

    IEnumerator stoppedCheck()
    {
        bool flag = true;
        yield return new WaitForSeconds(3f);
        while (flag)
        {
            if (rb.velocity.magnitude > 0)
            {
                Debug.Log("if" + rb.velocity.magnitude);
                Win(false);
                flag = true;
            }
            else
            {
                Debug.Log("else" + rb.velocity.magnitude);
                for(int i=0; i < 3; i++)
                {
                    yield return new WaitForSeconds(1f);
                }
                
                if(rb.velocity.magnitude <=0)
                {
                    flag = false;
                    Win(true);
                }
                

            }
            yield return null;
        }

        
    }

    void Win(bool t)
    {
        //Physics2D.autoSimulation = false;
        winPanel.SetActive(t);
        //StopAllCoroutines();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            obstacle = true;
        }

        if (other.gameObject.tag == "windArea")
        {
            windZone = other.gameObject;
            inWindZone = true;
        }

        if (other.gameObject.tag == "Finish")
        {
            lostPanel.SetActive(true);
        }

        if (other.gameObject.CompareTag("Spikes"))
        {
            Win(true);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            obstacle = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            obstacle = false;
        }
        if (other.gameObject.tag == "windArea")
        {
            windZone = other.gameObject;
            inWindZone = false;
        }
    }
}
