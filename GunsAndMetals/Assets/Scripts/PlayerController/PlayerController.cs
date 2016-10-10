using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Player Controller Vars
    private float horizontalInput;
    private float verticalInput;
    private bool isFacingRight=true;


    //Player Health and Life
    private int playerMaxHealth = 100;
    private int playerCurrentHealth = 100;
    



    //Animator
    private Animator anim;




	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        //Get the Keyboard Input
        horizontalInput =  Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Apply the input to the player
        GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalInput * Time.deltaTime*4300.0f, 200.0f*verticalInput * Time.deltaTime));
        if (horizontalInput > 0 && !isFacingRight) playerFlip();
        else if (horizontalInput < 0 && isFacingRight) playerFlip();
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

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
