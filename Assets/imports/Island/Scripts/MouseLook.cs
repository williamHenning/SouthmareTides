using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {

	public float mouseSensitivity = 100f;
	public GameObject gun;
	public Transform playerBody;
	float xRotation = 0f;
	float yRotation = 0f;
	void Update ()
	{
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

		yRotation -= mouseY;
		//makes it so you can only look straight up or straight down
		yRotation = Mathf.Clamp(yRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

		Debug.Log(gun.transform.rotation);
		gun.transform.RotateAround(transform.position, transform.right, -mouseY * 0.5f);
        
		playerBody.Rotate(Vector3.up * mouseX);
	}
	
	void Start ()
	{
		//hides cursor
		Cursor.lockState = CursorLockMode.Locked;
	}
}