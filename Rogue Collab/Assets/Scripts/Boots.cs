using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : MonoBehaviour {
   private Player player;
   public bool SuperFastBoots;
   public bool Boots;
   public float BootsSpeed;

   void Start() {
      player.GetComponent<Player>();
   }

   void Update() {
      if (Boots){
         player.MovementSpeed = BootsSpeed;
      }
      else if (SuperFastBoots) {
         player.MovementSpeed = BootsSpeed + 3;
      }

   }
}
