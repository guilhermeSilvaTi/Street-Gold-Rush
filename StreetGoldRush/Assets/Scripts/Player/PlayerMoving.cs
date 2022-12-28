using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField]
    Player player;
    [SerializeField]
    PlayerInput playerInput;
    [SerializeField]
    PlayerCollision playerCollision;
  
   
    void FixedUpdate()
    {
        if(StatesGame.GetActiveGame())
        MovingPlayerDirection();
    }

    private void MovingPlayerDirection()
    {    
       switch(player.direction)
        {
            case 2:
                {
                    if (transform.position.y < player.positionYPlayer[player.positionOnScreenPlayer-1])
                    {
                        transform.Translate(Vector2.up * player.velocity * Time.deltaTime);
                        player.animator.SetInteger("Player", 1);
                    }
                     else
                       {
                           player.direction =0;
                        player.animator.SetInteger("Player", 0);
                        player.positionOnScreenPlayer--;
                       }
                    break;
                }
            case -2:
                {
                    if (transform.position.y > player.positionYPlayer[player.positionOnScreenPlayer +1])
                    {
                        transform.Translate(Vector2.down * player.velocity * Time.deltaTime);
                        player.animator.SetInteger("Player", 2);
                    }
                    else
                    {
                        player.direction = 0;
                        player.animator.SetInteger("Player", 0);
                        player.positionOnScreenPlayer++;
                    }
                    break;
                }
        }

            

    }

}
