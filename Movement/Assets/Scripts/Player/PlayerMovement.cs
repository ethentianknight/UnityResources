using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public new Rigidbody rigidbody;
    public float movementSpeed = 10f;
    public float turnSmoothing = 2f;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var h = GetHorizontalInput();
        var v = GetVerticalInput();
        if (h != 0 || v != 0)
        {
            Rotate(h, v);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }

    private void Rotate(float h, float v)
    {
        Vector3 targetDir = new Vector3(h, 0f, v);
        Quaternion targetRot = Quaternion.LookRotation(targetDir, Vector3.up);
        Quaternion newRot = Quaternion.Lerp(rigidbody.rotation, targetRot, turnSmoothing * Time.deltaTime);
        rigidbody.MoveRotation(newRot);
    }

    private float GetHorizontalInput()
    {
        return (KeyPressRight() ? 1 : 0) - (KeyPressLeft() ? 1 : 0);
    }

    private float GetVerticalInput()
    {
        return (KeyPressUp() ? 1 : 0) - (KeyPressDown() ? 1 : 0);
    }

    private bool KeyPressUp()
    {
        return Input.GetKey(KeyCode.UpArrow)
            || Input.GetKey(KeyCode.W);
    }

    private bool KeyPressDown()
    {
        return Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.S);
    }

    private bool KeyPressLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.A);
    }

    private bool KeyPressRight()
    {
        return Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.D);
    }
}
