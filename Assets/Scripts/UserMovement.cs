using System;
using UnityEngine;

public class UserMovement : MonoBehaviour
{
    public static float HorizontalInput = 0f, VerticalInput = 0f, SideStepInput = 0f;
    private static float _directionalSpeed = 8f;
    private static float _rotationSpeed = _directionalSpeed * 7f;
    private static Transform _player;

    private void Awake()
    {
        _player = transform.parent;
    }

    private void FixedUpdate()
    {
        float horMovement = UserInput.MovementVector.x;
        float horCamera = UserInput.CameraVector.x;
        bool isCameraStronger = Math.Abs(horCamera) > Math.Abs(horMovement);

        HorizontalInput = isCameraStronger ? horCamera : horMovement;
        VerticalInput = UserInput.MovementVector.y;
        SideStepInput = UserInput.SideStepInput;

        _player.Translate(new Vector3(SideStepInput, 0f, VerticalInput) * _directionalSpeed * Time.deltaTime);
        _player.Rotate(new Vector3(0f, HorizontalInput, 0f) * _rotationSpeed * Time.deltaTime);
    }
}
