using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObjectScript : MonoBehaviour
{
    [SerializeField]
    EnumHability hability;

    [SerializeField]
    BoxCollider2D boxCollider2D;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    bool isDisactive;
    [SerializeField]
    AudioSource sound;

    private void Update()
    {
        if(!isDisactive)
        transform.Translate(Vector2.left * StatesGame.GetVelocity() * Time.deltaTime);
    }

    private IEnumerator SetHability()
    {
        StatesGame.SetHability(hability);
        print("magnetico" + StatesGame.GetHability());
        boxCollider2D.enabled = false;
        spriteRenderer.enabled = false;
        sound.Play();
        isDisactive = true;
        yield return new WaitForSeconds(10.5f);
        StatesGame.SetHability(EnumHability.Empty);
        print("Empty" + StatesGame.GetHability());
        boxCollider2D.enabled = false;
        spriteRenderer.enabled = false;
        isDisactive = false;
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SetHability());
        }
    }
}
