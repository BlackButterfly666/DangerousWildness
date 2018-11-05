using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//Variables
	public Transform cam;
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 cameraRot;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		Move();
		Rotate();
		RotateHead();
		FastMove();
		LockMouse();
		ReleaseMouse();
	}

	public void Move()
	{
		CharacterController controller = GetComponent<CharacterController>();

		// is the controller on the ground?
		if (controller.isGrounded)
		{
			//Feed moveDirection with input.
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			//Transform local values to world space
			moveDirection = transform.TransformDirection(moveDirection);

			//Multiply it by speed.
			moveDirection *= speed;
			//Jumping
			if (Input.GetButton("Jump")) moveDirection.y = jumpSpeed;
		}

		//Applying gravity to the controller
		moveDirection.y -= gravity * Time.deltaTime;
		//Making the character move
		controller.Move(moveDirection * Time.deltaTime);
	}

	private void Rotate() // Body turning - Player body
	{
		float yRot;
		yRot = Input.GetAxis("Mouse X");
		transform.rotation *= Quaternion.Euler(0f, yRot, 0f);
	}

	private void RotateHead() // Head noding - Camera
	{
		float xRot = Input.GetAxis("Mouse Y");
		xRot *= -1;
		Vector3 oldRot = cameraRot;

		cameraRot += new Vector3(xRot, 0f, 0f);
		if (cameraRot.x < -60 || cameraRot.x > 50f)
		{ cameraRot = oldRot; }
		cam.localRotation = Quaternion.Euler(cameraRot.x, cam.rotation.y, cam.rotation.z);
	}

	void FastMove()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift)) { speed *= 3f; }
		if (Input.GetKeyUp(KeyCode.LeftShift)) { speed /= 3f; }
	}

	public void LockMouse()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{ Cursor.lockState = CursorLockMode.Locked; }
	}

	public void ReleaseMouse()
	{
		if (Input.GetKeyDown(KeyCode.U))
		{ Cursor.lockState = CursorLockMode.None; }
	}
}