using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager> {

   public GameObject WallPrefab;
   public GameObject GroundPrefab;
   public GameObject PlayerPrefab;

   public Tile[,] Tiles;
   private int levelWidth;
   private int levelHeight;
   private Player player;

   private void Start() {
      levelWidth = 30;
      levelHeight = 30;
      Coordinates.Initialize(levelWidth, levelHeight);
      Tiles = new Tile[levelWidth, levelHeight];
      LoadLevel();

      //Spieler spawnen (zum testen auf Position (10, 10))
      player = Instantiate(PlayerPrefab, Coordinates.GetPooled(10, 10).ToWorldUnits(), Quaternion.identity).GetComponent<Player>();
      player.Position = Coordinates.GetPooled(10, 10);
   }

   private void LoadLevel() {
      //Für den Anfang nur zum Testen, ein hard-coded Testlevel
      //Wird später ersetzt

      for (int i = 0; i < levelWidth; i++) {
         for (int k = 0; k < levelHeight; k++) {
            //Erstelle die einzelnen Kacheln des Levels
            Coordinates pos = Coordinates.GetPooled(i, k);
            GameObject prefab;
            if (((pos.X > 10 && pos.X < 12) || (pos.Y == 12)) && !(pos.X == 7 && pos.Y == 12) && !(pos.X == 11 && pos.Y == 7) && !(pos.X == 17 && pos.Y == 12)) {
               prefab = WallPrefab;
            }
            else {
               prefab = GroundPrefab;
            }
            GameObject tileObj = Instantiate(prefab, pos.ToWorldUnits(), Quaternion.identity);
            Tiles[i, k] = tileObj.GetComponent<Tile>();

         }
      }
   }

   public Tile GetTileAtCoordinates(Coordinates coords) {
      return Tiles[coords.X, coords.Y];
   }
}
