using System;
using UnityEngine;

public class UserMovement : MonoBehaviour
{
    public static float HorizontalInput, VerticalInput, SideStepInput;
    private static float _directionalSpeed, _rotationSpeed;

    private void Start()
    {
        HorizontalInput = 0f;
        VerticalInput = 0f;
        SideStepInput = 0f;
        _directionalSpeed = 10f;
        _rotationSpeed = _directionalSpeed * 7f;
    }

    private void FixedUpdate()
    {
        float horMovement = UserInput.MovementVector.x;
        float horCamera = UserInput.CameraVector.x;
        bool isCameraStronger = Math.Abs(horCamera) > Math.Abs(horMovement);

        HorizontalInput = isCameraStronger ? horCamera : horMovement;
        VerticalInput = UserInput.MovementVector.y;
        SideStepInput = UserInput.SideStepInput;

        transform.Translate(new Vector3(SideStepInput, 0f, VerticalInput) * _directionalSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0f, HorizontalInput, 0f) * _rotationSpeed * Time.deltaTime);
    }
}
