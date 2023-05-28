using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private static float _verticalInput, _verticalLimit, _sensitivity;

    private void Start()
    {
        _verticalInput = 0f;
        _verticalLimit = 35f;
        _sensitivity = 0.5f;
    }

    private void LateUpdate()
    {
        // The camera horizontal movement rotates the user, and the camera is the user's child so it already rotates with it
        // All that is left to do is the vertical rotation

        // Update the input with the sensitivity
        _verticalInput += -UserInput.CameraVector.y * _sensitivity;

        // Clamp the input
        _verticalInput = Mathf.Clamp(_verticalInput, -_verticalLimit, _verticalLimit);

        // Rotate the camera
        transform.localRotation = Quaternion.Euler(_verticalInput, 0f, 0f);
    }
}
