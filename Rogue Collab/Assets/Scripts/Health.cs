using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
   public float Current;
   public float Max;
   public void Decrease(float dec) {
      Current -= dec;
   }
}

