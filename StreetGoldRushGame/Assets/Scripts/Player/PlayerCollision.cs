using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    Player player;
    [SerializeField]
    PlayerInput playerInput;  
    [SerializeField]
    PlayerMoving playerMoving;

    [SerializeField]
    GameOver gameOver;

    [SerializeField]
    AudioSource soundGameOver;
  
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
      

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            DeathPlayer();
        }
    }

    private void DeathPlayer()
    {
       StartCoroutine(gameOver.CallWindowGameOver());
        soundGameOver.Play();
        player.animator.SetInteger("Player", 3);
        player.boxCollider2D.enabled = false;
    }
}
