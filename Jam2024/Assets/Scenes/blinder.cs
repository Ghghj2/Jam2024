using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinder : MonoBehaviour
{

    [SerializeField] float charSpeed = 3f;
    [SerializeField] float minJumpForce = 5.0f;
    [SerializeField] float maxJumpForce = 5.17f;
    [SerializeField] float jumpChargeRate = 1.0f;
    [SerializeField] float gravityScale = 3.0f;
    private Rigidbody2D rb;
    bool isGrounded;
    float currentJumpForce;

    private bool isHoldingJump;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = Input.GetAxis("Horizontal") * this.charSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            isHoldingJump = true;
            currentJumpForce = minJumpForce;
            rb.velocity = new Vector2(rb.velocity.x, currentJumpForce);
        }

        if (Input.GetKey(KeyCode.Space) && isHoldingJump && currentJumpForce < maxJumpForce)
        {
            currentJumpForce +=  jumpChargeRate * Time.deltaTime;
            currentJumpForce = Mathf.Clamp(currentJumpForce, 0, maxJumpForce);
            rb.velocity = new Vector2(rb.velocity.x, currentJumpForce);
            rb.gravityScale = gravityScale * 0.5f;
            
        }
        if (Input.GetKeyUp(KeyCode.Space))  
        {
            isHoldingJump = false;
            rb.gravityScale = gravityScale; 
        }
        transform.Translate(moveSpeed, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Damage")){
            kill();
        }
    }

    void kill() {
        transform.position = spawnPoint.position;
    }
}