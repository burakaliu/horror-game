using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float movementSpeed = 10f;         // Speed of player movement
    public float sprintSpeed = 20f;          // Speed of player sprinting
    public float lookSensitivity = 5f;       // Sensitivity of mouse look

    private Rigidbody rb;
    private Camera playerCamera;
    private float rotationX = 0f;
    private bool isSprinting = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        // Get input axes
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Apply movement with the appropriate speed
        float currentSpeed = isSprinting ? sprintSpeed : movementSpeed;
        Vector3 moveVelocity = transform.TransformDirection(movement) * currentSpeed;
        // Check if the player is providing input for movement
        rb.AddForce(moveVelocity - rb.velocity, ForceMode.VelocityChange);
       

        // Apply rotation based on mouse movement
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        // Rotate the player horizontally
        transform.Rotate(Vector3.up, mouseX);

        // Rotate the camera vertically
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Check if Shift key is held down for sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    private void Update()
    {
        // In Update() method
        float smoothSpeed = 10f; // Adjust this value as needed

        // Rotate the camera vertically with smoothing
        Quaternion targetRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerCamera.transform.localRotation = Quaternion.Lerp(playerCamera.transform.localRotation, targetRotation, smoothSpeed * Time.deltaTime);


        // Unlock cursor on Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
