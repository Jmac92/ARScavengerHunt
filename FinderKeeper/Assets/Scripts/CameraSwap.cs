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
     }
 }
