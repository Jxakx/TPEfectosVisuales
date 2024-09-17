using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal"); // A y D
        float moveVertical = Input.GetAxis("Vertical"); // W y S

        
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
