using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    /*public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
	*/
    // Start is called before the first frame update
    /*void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText ();
        }
    }*/

    private Rigidbody rb;

    public float jumpForce;

    public Transform groundPoint;
    public LayerMask whatIsGround;

    public bool isGrounded = true;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private int count;
    private float movementX;
    private float movementY;
    public float speed;
    public float jumpCount;
    // Start is called before the first frame update
    void Start()
    {
    	rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //move the player
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        //check if on the ground
        //isGrounded = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText ();
        }
    }

    void OnCollisionEnter(Collision theCollision)
 	{
    	if (theCollision.gameObject.name == "Ground")
    	{
        	isGrounded = true;
        	jumpCount = 0;
     	}
 	}

 	void OnCollisionExit(Collision theCollision)
	{
	    if (theCollision.gameObject.name == "Ground")
	    {
	        isGrounded = false;
	    }
	}

    public void OnMove(InputAction.CallbackContext context){

    	Vector2 movementVector = context.ReadValue<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    public void OnJump(InputAction.CallbackContext context){
    	if(context.performed && isGrounded){
    		rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    		jumpCount = jumpCount + 1;
    	}else if( context.performed && jumpCount <= 1){
    		rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    		jumpCount = jumpCount + 1;
    	}
    }
}
