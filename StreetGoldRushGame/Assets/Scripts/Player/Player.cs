using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    PlayerInput playerInput;
    [SerializeField]
    PlayerCollision playerCollision;
    [SerializeField]
    PlayerMoving playerMoving;

    [SerializeField]
    internal int direction;

    [SerializeField]
    internal float[] positionYPlayer;

    [SerializeField]
    internal int positionOnScreenPlayer = 1;

    [SerializeField]
    internal float velocity = 10;

    [SerializeField]
   internal Animator animator;

    [SerializeField]
  internal  BoxCollider2D boxCollider2D;
    public void StartGame()
    {
       animator.SetInteger("Player", 0);
        transform.position = new Vector2(transform.position.x, positionYPlayer[1]);
        positionOnScreenPlayer = 1;
        velocity = 10;
        boxCollider2D.enabled = true;
        direction = 0;
    }
}
