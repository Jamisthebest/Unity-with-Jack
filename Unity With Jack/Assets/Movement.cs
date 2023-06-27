using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D Player;
    public float jumpStrength = 5f;
    public float moveSpeed = 5f;
    public float move;
    public int jumpCount;
    public bool canJump = true;
    public int maxJumps = 2;
    public bool facingRight = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        Jump();

        // Takes user input (A or D)
        move = Input.GetAxis("Horizontal");    //        direction          magnitude
        //sets the rigidbody's velocity as the (user input) * (move speed)
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);


        //On X axis: -1f is left, 1f is right

    //Player Movement. Check for horizontal movement
    if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) 
    {
        transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        if (Input.GetAxisRaw ("Horizontal") > 0.5f && !facingRight) 
        {
            //If we're moving right but not facing right, flip the sprite and set     facingRight to true.
            Flip ();
            facingRight = true;
        } else if (Input.GetAxisRaw("Horizontal") < 0.5f && facingRight) 
        {
            //If we're moving left but not facing left, flip the sprite and set facingRight to false.
            Flip ();
            facingRight = false;
        }

    //If we're not moving horizontally, check for vertical movement. The "else if" stops diagonal movement. Change to "if" to allow diagonal movement.
    } 
    
    else if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) 
    {
        transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
    }



    //Variables for the animator to use as params
    //anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
    //anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));

        
    

        void Jump()
        {
            if (jumpCount >= maxJumps)
            {
                canJump = false;
            }

            if (Input.GetKeyDown(KeyCode.Space) == true && canJump == true)
            {
                Player.velocity = Vector2.up * jumpStrength; //The rigidbody's velocity is set as an (upwards direction) * (jump magnitude)
                jumpCount += 1;
            }
        }

        void OnCollisionEnter2D(Collision2D coll){

        if(coll.gameObject.name == "Floor") // if there is a collision with the gameObject with name "Floor"
        {   // resets jumps
            canJump=true; 
            jumpCount = 0; 
        }
        }

    void Flip()
    {
    // Switch the way the player is labelled as facing
    facingRight = !facingRight;

    // Multiply the player's x local scale by -1
    Vector2 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
    } 
    
    }
}
