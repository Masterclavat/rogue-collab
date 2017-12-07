using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
   public float MovementSpeed;
   public Coordinates Position;

   private LevelManager levelManager;
   private bool isMoving;

   private void Awake() {
      levelManager = LevelManager.Instance;
   }

   private void Start() {
      CameraFollow follow = Camera.main.GetComponent<CameraFollow>();
      follow.FollowTransform = this.transform;
      follow.StartFollow();
   }

   public void Move(MoveDirection dir) {
      Coordinates newCoords = Position;
      switch (dir) {
         case MoveDirection.Left:
            newCoords = Coordinates.GetPooled(Position.X - 1, Position.Y);
            break;
         case MoveDirection.Up:
            newCoords = Coordinates.GetPooled(Position.X, Position.Y + 1);
            break;
         case MoveDirection.Right:
            newCoords = Coordinates.GetPooled(Position.X + 1, Position.Y);
            break;
         case MoveDirection.Down:
            newCoords = Coordinates.GetPooled(Position.X, Position.Y - 1);
            break;
      }
      if (newCoords == null)
         return;

      //Ändert die Richtung, in die der Player guckt
      switchSprite(dir);

      Tile tile = levelManager.GetTileAtCoordinates(newCoords);
      //Bewege den Spieler nur auf das Feld, wenn es auch betretbar ist
      if (tile != null && tile.Passable) {
         moveToPosition(newCoords);
      }
   }

   private void switchSprite(MoveDirection dir) {
      //Ändert die Richtung in die der Player guckt
      //Das hab ich für dich offen gelassen, Cedric
      //Falls du was suchst, was du machen kannst
      //Merk dir, auf die Sprites kannst du so zugreifen:
      //SpriteList.Instance.PlayerFront
      //Damit würdest du den Sprite bekommen, wo der Spieler nach unten guckt
      //Alle vier Richtungen sind bereits in der Klasse SpriteList, musst nur noch den richtigen zuweisen
   }

   private void moveToPosition(Coordinates pos) {
      //Wenn wir uns schon bewegen, mache nichts
      if (isMoving)
         return;
      //Startet eine Coroutine, die den Player zu der angegebenen Position bewegt
      //Coroutinen haben die besonderheit, dass sie
      StartCoroutine(moveSubroutine(pos));
      
      //Wenn wir uns bewegen, dürfen die Gegner auch einen Zug machen
      EnemyManager.Instance.MoveAllEnemies();
   }

   private IEnumerator moveSubroutine(Coordinates pos) {
      isMoving = true;
      //Die Coroutine wird solange ausgeführt, bis die Position des Spielers gleich der Position ist,
      //zu der wir laufen wollen
      Vector2 targetWorldPos = pos.ToWorldUnits();
      while (transform.position.x != targetWorldPos.x || transform.position.y != targetWorldPos.y) {
         transform.position = Vector3.MoveTowards(transform.position, targetWorldPos, Time.deltaTime * 5);

         //Die Zeile mit yield return bedeutet, dass die Schleife Pause macht, bis der Frame fertig ist
         //und beim nächsten Frame erst weitermacht
         yield return new WaitForEndOfFrame();
      }
      Position = pos;
      isMoving = false;
   }
}
public enum MoveDirection {
   Left, Up, Right, Down
}
