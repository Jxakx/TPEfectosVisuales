using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    public float verticalSpeed = 8f; 
    public float mouseSensitivity = 100f;

    private float mouseX, mouseY;

    void Update()
    {
        // Movimiento de la cámara (A, D, W, S)
        float moveHorizontal = Input.GetAxis("Horizontal"); // A y D
        float moveVertical = Input.GetAxis("Vertical"); // W y S

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Movimiento vertical (Q, E)
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime, Space.World);
        }

        // Rotación de la cámara con el mouse
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
    }
}
