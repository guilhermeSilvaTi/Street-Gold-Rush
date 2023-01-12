using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    Player player;
    [SerializeField]
    PlayerCollision playerCollision;
    [SerializeField]
    PlayerMoving playerMoving;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector3 currentSwipe;
    [SerializeField]
    AudioSource dashFX;
    void Update()
    {
        if (StatesGame.GetActiveGame())
        {
            Swipe();
            KeyboardTeste();
        }
    }
    public void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    UpController();
                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    DownController();
                }
                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {

                }
            }
        }
    }

    private void KeyboardTeste()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            DownController();

        if (Input.GetKeyDown(KeyCode.UpArrow))
            UpController();
    }
    private void DownController()
    {
        if (player.positionOnScreenPlayer == 1 || player.positionOnScreenPlayer == 0)
        {
            dashFX.Play();
            player.direction = -2;
        }

    }
    private void UpController()
    {

        if (player.positionOnScreenPlayer == 1 || player.positionOnScreenPlayer == 2)
        {
            dashFX.Play();
            player.direction = 2;
        }
    }

}
