using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
   public float MovementSpeed;
   public void Move(MoveDirection dir) {
      
   }
}
public enum MoveDirection {
   Left,Top,Right,Bottom
}
