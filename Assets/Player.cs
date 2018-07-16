using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float baseSpeed = 10.0f;
    [SerializeField] private float rotSpeedX = 3.0f;
    [SerializeField] private float rotSpeedY = 1.5f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 moveVector = transform.forward * baseSpeed;

        Vector3 inputs = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        Vector3 yaw = inputs.x * transform.right * rotSpeedX * Time.deltaTime;
        Vector3 pitch = inputs.y * transform.up * rotSpeedY * Time.deltaTime;
        Vector3 dir = yaw + pitch;

        moveVector += dir;

        transform.rotation = Quaternion.LookRotation(moveVector);

        controller.Move(moveVector * Time.deltaTime);
    }
}
