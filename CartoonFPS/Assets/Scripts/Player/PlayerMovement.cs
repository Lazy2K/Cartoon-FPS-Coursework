using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float mouseSensitivity;
    public Camera viewCamera;
    private Vector2 cameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        cameraRotation = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        cameraRotation.y += Input.GetAxis("Mouse X");
        cameraRotation.x += Input.GetAxis("Mouse Y") * -1;
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, - 80f, 80f);
        viewCamera.transform.eulerAngles = (Vector2)cameraRotation * mouseSensitivity;
        
    }
}
