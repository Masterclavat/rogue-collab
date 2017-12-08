using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : MonoBehaviour {
   private Player player;
   public bool HasSuperFastBoots;
   public bool HasBoots;
   public float BootsSpeed;

   void Start() {
      player.GetComponent<Player>();
   }

   void Update() {
      if (HasBoots){
         player.MovementSpeed = BootsSpeed;
      }
      else if (HasSuperFastBoots) {
         player.MovementSpeed = BootsSpeed + 3;
      }

   }
}
