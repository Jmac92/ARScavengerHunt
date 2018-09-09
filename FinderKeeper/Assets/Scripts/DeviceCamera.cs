using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceCamera : MonoBehaviour {

    private bool camAvailable;
    private WebCamTexture cam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;
    
    // Use this for initialization
	private void Start () {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0) {
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++) {
            if (!devices[i].isFrontFacing) {
                cam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (cam == null) {
            Debug.Log("ERR: no back camera found");
            return;
        }

        cam.Play();
        background.texture = cam;

        camAvailable = true;
	}
	
	// Update is called once per frame
	private void Update () {
        if (!camAvailable) return;

        float ratio = (float)cam.width / (float)cam.height;
        fit.aspectRatio = ratio;

        float scaleY = cam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -cam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
	}
}
