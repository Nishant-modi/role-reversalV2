using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jumpSpeed;
    public float fallGravityMultiplier;
    public float maxSpeed = 2;

    public bool jumpCheck;
    public bool dashCheck;
    public bool movementCheck;

    public Text xAxis;
    public Text yAxis;
    public Text zAxis;

    public GameObject lostPanel;
    public GameObject winPanel;
    public Rigidbody2D rb;
    public Collider2D cl;
    public Animator animator;

    private bool obstacle;
    public bool isJumping;
    private bool isStopped = false;

    public bool inWindZone = false;
    public GameObject windZone;

    IEnumerator temp;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        isJumping = true;
        obstacle = false;
        temp = stoppedCheck();
        StartCoroutine(temp);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xAxis.text = "" + rb.position.x;
        yAxis.text = "" + rb.position.y;
        zAxis.text = "0";

        int rbPos = (int)rb.gravityScale;
        float direction = -Mathf.Sign(Physics2D.gravity.y);
        Move = 1f;

        //rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (movementCheck && !isStopped)
        {
            rb.AddForce(new Vector2(speed * Move, rb.velocity.y));
            if (jumpCheck && !isJumping && obstacle)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed * rbPos * direction), ForceMode2D.Impulse);
                animator.SetBool("isWalking", false);
                animator.SetBool("isJumpingUp", true);
            }

            if (inWindZone)
            {
                if (windZone.GetComponent<WindArea>().direction.x >= 0)
                {
                    rb.AddForce(new Vector2(1, 0) * windZone.GetComponent<WindArea>().strength);
                }
                else
                {
                    rb.AddForce(new Vector2(-1, 0) * windZone.GetComponent<WindArea>().strength);
                }

            }
        }

        if(rb.velocity.x!=0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

           
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -2, maxSpeed),rb.velocity.y);
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
                
                if(rb.velocity.magnitude == 0)
                {
                    flag = false;
                    StartCoroutine(Win2(true));
                }
                

            }
            yield return null;
        }

        
    }

    IEnumerator Win2(bool t)
    {
        //Physics2D.autoSimulation = false;
        //rb.isKinematic = true;
        //yield return new WaitForSeconds(3f);
        winPanel.SetActive(t);
        yield return null;
        //StopAllCoroutines();
    }

    IEnumerator Win(bool t)
    {
        //Physics2D.autoSimulation = false;
        //rb.isKinematic = true;
        StopCoroutine(temp);
        yield return new WaitForSeconds(1.5f);
        cl.enabled = false;
        
        yield return new WaitForSeconds(1.5f);
        winPanel.SetActive(t);
        yield return null;
        //StopAllCoroutines();
    }

    IEnumerator Lost(bool t)
    {
        //Physics2D.autoSimulation = false;
        //rb.isKinematic = true;
        StopCoroutine(temp);
        yield return new WaitForSeconds(3f);
        lostPanel.SetActive(t);
        yield return null;
        //StopAllCoroutines();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("isJumpingUp", false);
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
            isStopped = true;
            animator.Play("Player_Win");
            StartCoroutine(Lost(true));
        }

        if (other.gameObject.CompareTag("Spikes"))
        {
            isStopped = true;
            
            animator.Play("Player_Death", -1, 0f);
            //animator.StopPlayback("Player_Death");
            StartCoroutine(Win(true));
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
