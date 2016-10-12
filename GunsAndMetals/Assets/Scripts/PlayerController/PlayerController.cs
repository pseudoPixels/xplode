using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Player Controller Vars
    private float horizontalInput;
    private float verticalInput;
    private bool isFacingRight=true;


    public float maxSpeed = 10.0f;


    //Player Health and Life
    private int playerMaxHealth = 100;
    private int playerCurrentHealth = 100;
    



    //Animator
    private Animator anim;
    


    //Shooting and Actions
    





	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
       
    }


    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !isFacingRight) playerFlip();
        else if (move < 0 && isFacingRight) playerFlip();
    }
	
	// Update is called once per frame
	void Update () {
        //Get the Keyboard Input
        horizontalInput =  Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");



        //Apply the input to the player for Horizontal and vertical inputs
       /* GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalInput * Time.deltaTime*4300.0f, 200.0f*verticalInput * Time.deltaTime));
        if (horizontalInput > 0 && !isFacingRight) playerFlip();
        else if (horizontalInput < 0 && isFacingRight) playerFlip();
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        */
        
        
        //Player shooting 
        if (Input.GetButton("Fire1")){
                anim.SetBool("Shoot",true);
        }
        else{
            anim.SetBool("Shoot", false);
        }



    }

    void playerFlip(){
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public bool isPlayerAlive(){
        if (playerCurrentHealth <= 0) return false;
        return true;
    }
}
