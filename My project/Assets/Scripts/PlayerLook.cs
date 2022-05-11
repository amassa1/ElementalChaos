using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity;
    private float verticalRotation;
    public Transform playerTransform;
 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        //Gets the mouse input horizontally and vertically respectivelly
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Makes sure that the vertical rotation is limited to 180 degrees
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        //Rotates the view and the player based on mouse moving horizontally
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX);
    }

}
