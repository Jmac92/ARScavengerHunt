using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
 {
     public Camera IsometricCamera, ThirdPersonCamera;
     public bool swapFlag = false;

     public void Swap()
     {
         swapFlag = !swapFlag;
         IsometricCamera.gameObject.SetActive(swapFlag);
         ThirdPersonCamera.gameObject.SetActive(!swapFlag);
     }
 }
