using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Player Controller Vars
    private bool isFacingRight=true;
    public float maxSpeed = 10.0f;
    private bool isGrounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 700.0f;
    private bool doubleJump = false;


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

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        if (isGrounded) doubleJump = false;


        //Controll Player Horizontal Movement on input
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);



        //Face towards the moving direction
        if (move > 0 && !isFacingRight) playerFlip();
        else if (move < 0 && isFacingRight) playerFlip();




    }
	
	// Update is called once per frame
	void Update () {
        
        if((isGrounded==true || !doubleJump)&& Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            if (!doubleJump && !isGrounded) doubleJump = true;
        }
        
        //Player shooting 
        /*if (Input.GetButton("Fire1")){
                anim.SetBool("Shoot",true);
        }
        else{
            anim.SetBool("Shoot", false);
        }*/



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
