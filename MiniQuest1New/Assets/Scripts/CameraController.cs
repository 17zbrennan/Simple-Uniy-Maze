//Zachary Brennan 1/24/2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //Variables
    private Vector3 offset;
    private Quaternion rotationQuat;

    public GameObject player;

	void Start () {
        //Creates the offset
        offset = Camera.main.transform.position - player.transform.position;
	}
	
    private void LateUpdate()
    {
        //Keeps camera following player
        Camera.main.transform.position = player.transform.position + offset;

        //Makes a Quaternion that changes via Mouse's X axis
        rotationQuat = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 5, Vector3.up);
        //Changes the offset to stay the same with the rotation
        offset = rotationQuat * offset;
        //Focuses camera on the player
        transform.LookAt(player.transform.position);
    }
}
