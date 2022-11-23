using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	
	public float Speed;
    public float JumpForce;
	private float Horizontal;
    
	private bool Grounded;
	
	private Rigidbody2D Rigidbody2D;
	private Animator Animator;
	
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
		Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		Horizontal = Input.GetAxisRaw("Horizontal");
		
		if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
		
		Animator.SetBool("walking", Horizontal != 0.0f);
		
		UnityEngine.Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 1.1f)){
            Grounded = true;
			Animator.SetBool("jumping", false);
        }
        else
        {
            Grounded = false;
			Animator.SetBool("jumping", true);
        }

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
        
    }
	private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
	
	private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }
}
