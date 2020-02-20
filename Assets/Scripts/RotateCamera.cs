using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour

{

    private float rotSpeed = 50;
    public float rotSpeedActive;
    // Start is called before the first frame update
    void Start()
    {
        rotSpeedActive = rotSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space)) {
            rotSpeedActive = rotSpeed * 3;
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            rotSpeedActive = rotSpeed;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotSpeedActive * Time.deltaTime);
    }
}
