using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    Vector3 direction;

    [SerializeField] private float mouseSense;

    [SerializeField] Transform player;
    public Camera cam;
    public float xRotation;
    private void Start()
    {
        Transform currentRotation = cam.transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player = GetComponent<Transform>();
        Application.targetFrameRate = 60;
    }

    void CamControl()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -30f, 30f);
        player.Rotate(Vector3.up * mouseX);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

    }

    private void Update()
    {
        CamControl();
    }
}
