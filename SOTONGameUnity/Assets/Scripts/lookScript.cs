using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookScript : MonoBehaviour
{

    public float mouseSensitivity = 175f;
    public Transform beetleBody;
    float xRot = 0f;
    float fov;

    // Start is called before the first frame update
    void Start()
    {
        fov = 65f;
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            fov = 40f;
        }
        else
        {
            fov = 65f;
        }

        Camera.main.fieldOfView = fov;

        float mouseX = Input.GetAxis("Mouse X")* mouseSensitivity* Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")* mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        beetleBody.Rotate(Vector3.up * mouseX);
        

    }
}
