using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
   public Transform FollowTransform;
   private bool follow;
   private void Start() {

   }

   private void LateUpdate() {
      if (!follow || FollowTransform == null) {
         return;
      }
      transform.position = FollowTransform.position;
   }

   public void StartFollow() {
      follow = true;
   }

   public void StopFollow() {
      follow = false;
   }
}
