using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    bool isActive;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector2.left * StatesGame.GetVelocity() * Time.deltaTime);

        if (transform.position.x < -30.94 && isActive)
            Disable();
    }

    public void Active(float valueY)
    {
        if (!isActive)
        {
            transform.position = new Vector2(12.3f, valueY);
            isActive = true;
            this.gameObject.SetActive(true);
        }
    }
    public void Disable()
    {
        isActive = false;
        this.gameObject.SetActive(false);
    }
}
