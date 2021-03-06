﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
   public Transform FollowTransform;
   private bool follow;
   private void LateUpdate() {
      if (!follow || FollowTransform == null) {
         return;
      }
      transform.position = FollowTransform.position - new Vector3(0, 0, 5);
   }

   public void StartFollow() {
      follow = true;
   }

   public void StopFollow() {
      follow = false;
   }
}
