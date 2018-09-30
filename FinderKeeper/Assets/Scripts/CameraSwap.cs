using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour {
    [SerializeField]
    Camera _isometricCamera;

    [SerializeField]
    Camera _thirdPersonCamera;

    [SerializeField]
    GameObject _radarPulse;

    bool _isIsoCamera = true;

    public void Swap() {
        _isIsoCamera = !_isIsoCamera;
        _isometricCamera.gameObject.SetActive(_isIsoCamera);
        _thirdPersonCamera.gameObject.SetActive(!_isIsoCamera);

        var position = _radarPulse.transform.localPosition;
        if (_isIsoCamera) {
            position.z = 0;
        } else {
            position.z = -12;
        }
        _radarPulse.transform.localPosition = position;
    }
}
