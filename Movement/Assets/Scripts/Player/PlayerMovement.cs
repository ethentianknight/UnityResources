using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float turnSmoothing = 3f;
    public new Rigidbody rigidbody;
    public float movementSpeed = 10f;
    private float up;
    private float down;
    private float left;
    private float right;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        up = Input.GetKey("w") ? 1 : 0;
        down = Input.GetKey("s") ? 1 : 0;
        left = Input.GetKey("a") ? 1 : 0;
        right = Input.GetKey("d") ? 1 : 0;
        float h = right - left;
        float v = up - down;
        RotationManagement(h, v);
    }

    void RotationManagement(float horizontal, float vertical)
    {
        if (horizontal != 0f || vertical != 0f)
        {
            Rotating(horizontal, vertical);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }

    void Rotating(float horizontal, float vertical)
    {
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
        rigidbody.MoveRotation(newRotation);
    }
}
