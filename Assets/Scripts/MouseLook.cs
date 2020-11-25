using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    //public float clampAngle = 20.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    public bool canMove;
    
    [SerializeField] private Vector3 rot;

    void Start()
    {
        rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        StartCoroutine(StartMovement(2.0f));
    }

    IEnumerator StartMovement(float time)
    {
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    void Update()
    {
        if(!canMove) { return; }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseY * mouseSensitivity * Time.deltaTime;
        rotX += mouseX * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -20f, 20f);
        rotY = Mathf.Clamp(rotY, -25f, 50f);
        
        Quaternion localRotation = Quaternion.Euler(rotY, rotX, 0.0f);

        rot = localRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(rot);
    }
}
