//using UnityEngine;
//using System.Collections;

//public class OldMovement : MonoBehaviour {

//    public float turnSmoothing = 2f;
//    public new Rigidbody rigidbody;
//    public float movementSpeed = 0.5f;

//    void Start()
//    {
//        rigidbody = GetComponent<Rigidbody>();
//    }

//	void Update () {
//        float h = Input.GetAxis("Horizontal");
//        float v = Input.GetAxis("Vertical");

//        MovementManagement(h, v);
//	}

//    void MovementManagement(float horizontal, float vertical)
//    {
//        if (horizontal != 0f || vertical != 0f)
//        {
//            Rotating(horizontal, vertical);
//            transform.Translate(Vector3.forward * movementSpeed);
//        }
//    }

//    void Rotating(float horizontal, float vertical)
//    {
//        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
//        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
//        Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
//        rigidbody.MoveRotation(newRotation);
//    }
//}
