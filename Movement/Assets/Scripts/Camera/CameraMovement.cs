using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject Target;
    private float RotateSpeed = 3;
    private Vector3 Offset;
    private Quaternion HorizontalRotation;
    private Quaternion VerticalRotation;

    void Start()
    {
        Offset = Target.transform.position - transform.position;
        HorizontalRotation = Quaternion.Euler(0, 0, 0);
        VerticalRotation = Quaternion.Euler(0, 0, 0);
        //TODO: Determine where this belongs.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        MouseMovement();
    }

    void MouseMovement()
    {
        MouseHorizontal();
        MouseVertical();
        transform.position = Target.transform.position - (HorizontalRotation * VerticalRotation * Offset);
        transform.LookAt(Target.transform);
    }

    void MouseHorizontal()
    {
        float horizontal = Input.GetAxis("Mouse X") * RotateSpeed;
        Quaternion rotation = Quaternion.Euler(0, horizontal, 0);
        HorizontalRotation = HorizontalRotation * rotation;
    }

    void MouseVertical()
    {
        float vertical = Input.GetAxis("Mouse Y") * RotateSpeed;
        //flip vertical to make mouse up look up.
        Quaternion rotation = Quaternion.Euler(-vertical, 0, 0);
        VerticalRotation = VerticalRotation * rotation;
    }

}
