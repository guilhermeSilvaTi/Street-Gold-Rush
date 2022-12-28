using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    [SerializeField]
    float[] YPos;

    float deaultX = 13.08f;

    [SerializeField]
    GameObject[] BonusObject;

    int countBonus = 0;
 
    public void CallBonus(int value)
    {
       
         BonusObject[countBonus].SetActive(true);
        BonusObject[countBonus].transform.position = new Vector2(deaultX, YPos[value]);

        if (countBonus < BonusObject.Length - 1)
            countBonus++;
            else
            countBonus = 0;

    }

}
