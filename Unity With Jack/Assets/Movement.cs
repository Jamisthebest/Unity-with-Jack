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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        Jump();


        move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        
    }
    void Jump()
    {
        if (jumpCount >= maxJumps)
        {
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) == true && canJump == true)
        {
            Player.velocity = Vector2.up * jumpStrength;
            jumpCount += 1;
        }
    }

        void OnCollisionEnter2D(Collision2D coll){

        if(coll.gameObject.name == "Floor")
        {
            canJump=true;
            jumpCount = 0;
        }
    }
}