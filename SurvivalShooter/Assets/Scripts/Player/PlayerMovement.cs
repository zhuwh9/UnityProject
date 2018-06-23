using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6.0f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100.0f;

	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
//		float h = Input.GetAxisRaw ("Horizontal");
//		float v = Input.GetAxisRaw ("Vertical");
		float h = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
		float v = CrossPlatformInputManager.GetAxisRaw ("Vertical");
		float h1 = CrossPlatformInputManager.GetAxisRaw ("Horizontal1");
		float v1 = CrossPlatformInputManager.GetAxisRaw ("Vertical1");

		Move (h, v);
		Turning (h1, v1);
		Animating (h, v);
	}

	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;//movement.normalized是只有方向的单位向量
		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Turning(float h, float v)
	{
		Vector3 orientation = new Vector3 (h, 0.0f, v);
		orientation = orientation.normalized;
		Quaternion newRotation = Quaternion.LookRotation (orientation);
		playerRigidbody.MoveRotation (newRotation);
	}

	// this is for PC platform
//	void Turning()
//	{
//		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
//
//		RaycastHit floorHit;
//
//		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
//		{
//			Vector3 playerToMouse = floorHit.point - transform.position;
//			playerToMouse.y = 0f;
//
//			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
//			playerRigidbody.MoveRotation (newRotation);
//		}
//	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}
}
