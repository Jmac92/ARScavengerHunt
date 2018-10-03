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

    public bool isIsoCamera = true;

    public void Swap() {
        isIsoCamera = !isIsoCamera;
        _isometricCamera.gameObject.SetActive(isIsoCamera);
        _thirdPersonCamera.gameObject.SetActive(!isIsoCamera);

        var position = _radarPulse.transform.localPosition;
        if (isIsoCamera) {
            position.z = 0;
        } else {
            position.z = -12;
        }
        _radarPulse.transform.localPosition = position;
    }
}
