using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [Range(-1f, 10f)]
    [SerializeField]
    float scrollSpeed = 0.5f;
    private float offset;

    Material material;


    private void Start()
    {
        material = GetComponent<Renderer>().material;
       
    }

    void Update()
    {
        if (StatesGame.GetActiveGame())
        {
            offset += (Time.deltaTime * scrollSpeed * StatesGame.GetVelocity()) / 10f;
            material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
