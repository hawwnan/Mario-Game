using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed = 10f;
    public float JumpForce = 6f;
    public Transform groundCheck;
    public LayerMask ground;
    public AudioSource JumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        //we multiply our movement in + or - direction with the velocity we want to assign
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        //button refers to input buttons in unity
        if(Input.GetButtonDown("Jump") && IsGrounded()){
           Jump();
            /*we stop falling down or keep in air when we press the key bcz
            we have zeroed the velocity in all other directions. so we have to keep
            the velocity of previous frame to overcome that*/
        }
    }
 

    void Jump(){
        rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
        JumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy Head")){
            //refers to the whole enemy body
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGrounded(){
        /*we want to check if our groundcheck overlaps with the ground*/
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
        //Physics.CheckSphere() : Returns true if there are any colliders overlapping the sphere defined by position and radius in world coordinates
    }
}
