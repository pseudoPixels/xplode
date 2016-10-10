using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private PlayerController playerController;
    private Transform playerTransform;


    private Vector3 cameraNewPosition;


	// Use this for initialization
	void Start () {
        playerController = player.GetComponent<PlayerController>();
        playerTransform = player.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(playerController.isPlayerAlive() == true){
            cameraNewPosition = new Vector3(playerTransform.position.x+3.0f, playerTransform.position.y+3.0f, transform.position.z);
            transform.position = cameraNewPosition;
        }
	}
}
