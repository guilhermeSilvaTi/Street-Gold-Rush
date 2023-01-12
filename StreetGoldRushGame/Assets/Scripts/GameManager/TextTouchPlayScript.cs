using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTouchPlayScript : MonoBehaviour
{
    [SerializeField]
    GameObject configButton;

    float time;

    bool isEnabledText;
    void Update()
    {
        time += Time.deltaTime;
        if(time >0.8f)
        {
            if (isEnabledText)
            {
                configButton.SetActive(true);
                isEnabledText = false;
            }
            else
            {
                configButton.SetActive(false);
                isEnabledText = true;
            }

            time = 0;
        }
        
    }

   
}
