using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {


    public float acc = 8.0f;
    public float maxVelocity = 4f;
    private Rigidbody2D playerBody;
    private Animator animator;


    void Awake()
    {
        //get the components here
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// FixedUpdate is good to deal with physics
	void FixedUpdate () {

        playerMoveKeyBoard();

	}

    void playerMoveKeyBoard() {

        float forceX = 0f;
        float velocity = Mathf.Abs(playerBody.velocity.x);
        
        //h=-1||0||1 if left ||no key||right
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 temp = transform.localScale;
        
        if (h > 0)
        {
            if (velocity < maxVelocity)
                forceX = acc;

            animator.SetBool("Walk", true);
            temp.x = 1.4f;
        }
        else if (h < 0)
        {

            if (velocity < maxVelocity)
                forceX = -acc;
            animator.SetBool("Walk", true);
            temp.x = -1.4f;

        }
        else if (h == 0)
        {
            animator.SetBool("Walk", false);
        }
        transform.localScale = temp;
        playerBody.AddForce(new Vector2(forceX, 0));
       
    }
}
