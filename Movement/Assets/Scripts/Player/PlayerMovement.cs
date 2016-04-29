using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public new Rigidbody rigidbody;
    public float movementSpeed = 10f;
    public float turnSmoothing = 2f;
    public GameObject view;
    //TODO: move this outside of this class
    public enum Controls { classic, global };
    public Controls controlScheme;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //TODO: move this outside of this class
        controlScheme = Controls.global;
    }

    void Update()
    {
        ToggleMovement();
        Move();
    }

    private void ToggleMovement()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch (controlScheme)
            {
                case Controls.classic:
                    controlScheme = Controls.global;
                    break;
                case Controls.global:
                    controlScheme = Controls.classic;
                    break;
            }
        }
    }

    private void Move()
    {
        switch (controlScheme)
        {
            case Controls.classic:
                MoveClassic();
                break;
            case Controls.global:
                MoveGlobal();
                break;
        }
    }

    private void MoveGlobal()
    {
        var h = GetHorizontalInput();
        var v = GetVerticalInput();
        if (h != 0 || v != 0)
        {
            Rotate(h, v);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }

    private void MoveClassic()
    {
        if (!KeyPressDown())
        {
            MoveGlobal();
        }
        else
        {
            var h = GetHorizontalInput();
            var v = GetVerticalInput();
            if (h != 0 || v != 0)
            {
                Rotate(-h, -v);
                transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
            }
        }
    }

    private void Move(bool Forward)
    {

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
