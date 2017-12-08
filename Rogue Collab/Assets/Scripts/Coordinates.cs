using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates {

   public int X;
   public int Y;

   private static Coordinates[,] PooledCoordinates;
   private static bool initialized;
   public static Coordinates GetPooled(int x, int y) {
      //Wenn versucht wird, auf die PooledCoordinates zuzugreifen, bevor sie initialisiert wurden, gib nichts zurück
      if (!initialized)
         return null;
      //Wenn die übergebenen Koordinaten nicht innerhalb unseres Feldes sind, wird nichts zurückgegeben
      if (x < 0 || x >= PooledCoordinates.GetLength(0) || y < 0 || y >= PooledCoordinates.GetLength(1))
         return null;

      //Ansonsten wird die Instanz mit den angegebenen X und Y Werten zurückgegeben
      return PooledCoordinates[x, y];
   }

   public static void Initialize(int width, int height) {
      //Initialisiere das Array von Koordinaten
      //Zum Beispiel in PooledCoordinates[1, 2] liegt danach das Koordinatenpaar mit X = 1 und Y = 2
      PooledCoordinates = new Coordinates[width, height];
      for (int i = 0; i < width; i++) {
         for (int k = 0; k < height; k++) {
            PooledCoordinates[i, k] = new Coordinates(i, k);
         }
      }

      initialized = true;
   }

   public Coordinates(int x, int y) {
      X = x;
      Y = y;
   }

   public Coordinates() : this(0, 0) { }

   public Vector2 ToWorldUnits() {
      //Rechnet die Position als Vektor in WorldUnits aus, anhand der Koordinaten
      //Damit können wir Objekte in Unity positionieren, wenn wir nur die Koordinaten haben
      Vector2 tilePos = new Vector3(0.5f + X, 0.5f + Y, 1);

      return tilePos;
   }
}
