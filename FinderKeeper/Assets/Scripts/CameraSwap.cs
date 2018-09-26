using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
 {
     public Camera IsometricCamera, ThirdPersonCamera;
     public bool isIsoCamera = true;

     public void Swap()
     {
         isIsoCamera = !isIsoCamera;
         IsometricCamera.gameObject.SetActive(isIsoCamera);
         ThirdPersonCamera.gameObject.SetActive(!isIsoCamera);

         GameObject radar = GameObject.FindGameObjectWithTag("RadarPulse");
         var position = radar.transform.localPosition;
         if (isIsoCamera) {
             position.z = 0;
         } else {
             position.z = -12;
         }
         radar.transform.localPosition = position;
     }
 }
