using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager> {

   public List<Enemy> Enemies = new List<Enemy>();

   public void MoveAllEnemies() {
      foreach (Enemy enemy in Enemies) {
         enemy.DoAction();
      }
   }
}
