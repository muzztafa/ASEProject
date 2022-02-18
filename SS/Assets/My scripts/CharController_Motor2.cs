/* 
 @CharController_Motor.cs
 The below code is to define the first player's various attributes such as speed, gravity, camera Rotation (from first person veiw).
 
 *//*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharController_Motor2 : MonoBehaviour {

	public float speed = 10.0f; // This defines the speed at which player runs
	CharacterController character; // Controller of the first person Character
	public GameObject cam; // Camera of First Person Player
	float moveFB, moveLR; //
	//float rotX, rotY;
	float gravity = -9.8f; // Define a gravity of Character



	public float SpeedH = 10f; // Mouse Speed in Horizontal Direction
	public float SpeedV = 10f; // Mouse Speed in Vertical Direction
	private static float yaw = 0f; 
	private static float pitch = 0f;
	private float minPitch = -30f;
	private float maxPitch = 30f;


	void Start(){
		character = GetComponent<CharacterController> (); // Initializing the game object
	}



	void Update(){
		moveFB = Input.GetAxis ("Horizontal") * speed;  // Calculation for movement of Front and Back 
		moveLR = Input.GetAxis ("Vertical") * speed; // Calculation for movement of Left and Right 

		yaw += Input.GetAxis("Mouse X") * SpeedH; // Calculation for x axis movement
		pitch -= Input.GetAxis("Mouse Y") * SpeedV; // Calculation for y axis movement
		pitch = Mathf.Clamp(pitch, minPitch, maxPitch); // Range of Y axis movement is from -30 ro 30 degree


		Vector3 movement = new Vector3 (moveFB, gravity, moveLR); // All the movement are stored in the vector

		CameraRotation (cam, yaw, pitch);  

		if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) //this will check which key is used accordingly the movement of the first player occurs.
		{
			movement = transform.rotation * movement; 
		}
		character.Move (movement * Time.deltaTime);
	}


	void CameraRotation(GameObject cam, float yaw, float pitch) // Camera cursor rotation of First Player 
	{
		transform.eulerAngles = new Vector3(pitch, yaw, 0f);
		cam.transform.eulerAngles = new Vector3(pitch, yaw, 0f);
	}




}
*/