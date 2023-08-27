using UnityEngine;
using UnityEngine.InputSystem;

public class DetectPlayerVersion : MonoBehaviour
{
    [SerializeField] private InputActionReference _vrHeadsetTrackingState;
    [SerializeField] private GameObject _player3D;
    [SerializeField] private GameObject _playerVR;
    [SerializeField] private GameObject[] _vrRayInteractors;
    private float _timePassed = 0f;

    private void Awake()
    {
        /*
            If the VR player is not active by default, then the headset will never be detected.
            Of course, if no headset is plugged in, the 3D version will be used.

            The other advantage of having at least one active player version is that while we are 
            waiting for the detection to occur, we have something to look at instead of a black screen.
    
            Note that the VR interactors are inactive until the VR version is activated. The reason 
            being that otherwise they show for a few seconds for the 3D version and I'd rather they don't.
        */
        _playerVR.SetActive(true);
    }

    private void Update()
    {
        bool isTracked = _vrHeadsetTrackingState.action.ReadValue<int>() != 0;
        _timePassed += Time.deltaTime;

        if (_timePassed > 1f)
        {
            Activate3D();
            Destroy(this);
        }
        else if (isTracked)
        {
            ActivateVR();
            Destroy(this);
        }
    }

    private void Activate3D()
    {
        _player3D.SetActive(true);
        _playerVR.SetActive(false);
    }

    private void ActivateVR()
    {
        _playerVR.transform.localPosition = new Vector3(0f, -1f, 0f);
        _vrRayInteractors[0].SetActive(true);
        _vrRayInteractors[1].SetActive(true);
        _playerVR.SetActive(true);
        _player3D.SetActive(false);
    }
}
