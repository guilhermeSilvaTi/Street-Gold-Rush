using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ManagerCoin : MonoBehaviour
{
    [SerializeField]
    GameObject[] coinGroup;

    int numberCounCoin;

    int numberDefaultCoin =7;

    [SerializeField]
    float[] positionYCoins;

    [SerializeField]
    TextMeshProUGUI textCoin;
    void Start()
    {    
        coinGroup = GameObject.FindGameObjectsWithTag("Coin");
        foreach (var item in coinGroup)
            item.SetActive(false);
    }

   public void CallCoinGroup(int valueY)
    {
        float xCoin = 12.3f;
        for(int i =0; i < numberDefaultCoin;i++)
        {
            coinGroup[numberCounCoin].SetActive(true);
            coinGroup[numberCounCoin].transform.position = new Vector2(xCoin, positionYCoins[valueY]);

            xCoin += 0.8f;
            if (numberCounCoin < coinGroup.Length - 1)
                numberCounCoin++;
            else
                numberCounCoin = 0;
        }
       
    }

    public void UpdateCoin()
    {
        textCoin.text =  ""+ StatesGame.GetCoin();
    }

    public void ResetAll()
    {
        UpdateCoin();
        foreach (var item in coinGroup)
            item.SetActive(false);
    }


}
