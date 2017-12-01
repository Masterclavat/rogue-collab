using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
   private Player player;

   private void Awake() {
      player = GetComponent<Player>();
   }
   private void Update() {
      HandleMovement();
   }

   private void HandleMovement() {
      if (Input.GetKey(KeyCode.A)) {
         player.Move(MoveDirection.Left);
      }
      else if (Input.GetKey(KeyCode.D)) {
         player.Move(MoveDirection.Right);
      }
      else if (Input.GetKey(KeyCode.W)) {
         player.Move(MoveDirection.Top);
      }
      else if (Input.GetKey(KeyCode.S)) {
         player.Move(MoveDirection.Bottom);
      }
   }
}