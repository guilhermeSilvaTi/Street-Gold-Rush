using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    int valueCoin = 1;
    bool stopMoving;

    [SerializeField]
    BoxCollider2D boxCollider2D;

    [SerializeField]
    Animator animator;

    [SerializeField]
    AudioSource coinFx;
    [SerializeField]
    ManagerCoin managerCoin;

    [SerializeField]
    Transform playerTransform;
  
    void Update()
    {
        if (!stopMoving)
        {
            
            if (StatesGame.GetHability() == EnumHability.Magnetic && Vector2.Distance(playerTransform.position, transform.position) < 5)
            {      
                CheckPositionPlayer();
            }
            else
            transform.Translate(Vector2.left * StatesGame.GetVelocity() * Time.deltaTime);

            
        }
       
    }

    private void CheckPositionPlayer()
    {
        if (playerTransform.position.y+1 < transform.position.y)
            transform.Translate(Vector2.down * StatesGame.GetVelocity() * Time.deltaTime);
        else
        {
            if (playerTransform.position.y+1 > transform.position.y)
                transform.Translate(Vector2.up * StatesGame.GetVelocity() * Time.deltaTime);
        }
            transform.Translate(Vector2.left * StatesGame.GetVelocity() * Time.deltaTime);     
    }

    private IEnumerator CoinCapture()
    {
        StatesGame.SetCoin(valueCoin);
        managerCoin.UpdateCoin();
        boxCollider2D.enabled = false;
        animator.SetBool("IsCoin", false);
        stopMoving = true;     
        coinFx.Play();
        yield return new WaitForSeconds(1.5f);
        StartCoin();
    }

    public void StartCoin()
    {
        transform.position = new Vector2(-17.77f, 0);
        animator.SetBool("IsCoin", true);
        boxCollider2D.enabled = true;
        stopMoving = false;
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           StartCoroutine( CoinCapture());
        }
    }

   
}
