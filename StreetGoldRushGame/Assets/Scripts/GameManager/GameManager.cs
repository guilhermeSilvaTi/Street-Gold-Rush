using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    float time;

    [SerializeField]
    ObstleManager obstleManager;

    [SerializeField]
    ManagerCoin managerCoin;

    int[] randomValue = new int[3];

    [SerializeField]
    GameObject button;

    int counttoNextLevel = 1;

    [SerializeField]
    TextMeshProUGUI levelText;

    [SerializeField]
    AudioSource startSound;

    float timeGame;
  
    float timeToBonus = 28;
    [SerializeField]
    BonusScript Bonus;
    public  void StartGameNow()
    {
        StatesGame.SetActiveGame(true);
        startSound.Play();
        button.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        if(StatesGame.GetActiveGame())
        {
            time += Time.deltaTime;
            timeGame += Time.deltaTime;

            if(time > StatesGame.GetTimeRespwan())
            {
                CallNewObject();
                time = 0;           
                CheckNextLevel();
            }
        }
        
    }

    private void CallNewObject()
    {
        for (int i=0; i < randomValue.Length; i++)
        {
            randomValue[i] = UnityEngine.Random.Range(0, 2);
           // print("valores " + randomValue[i]);
        }

        if (randomValue[0] == 1 && randomValue[1] == 1 && randomValue[2] == 1)
        {
            int randomCoin =  UnityEngine.Random.Range(0, 3);
            randomValue[randomCoin] = 0;
        }

        CheckTypeObstacle();
    }

    private void CheckTypeObstacle()
    {
        for (int i = 0; i < randomValue.Length; i++)
        {
            // print("valores " + randomValue[i]);
            if (randomValue[i] == 0)
            {
                EmptySpace(i);
            }
            else
                obstleManager.CallObstacleGroup(i);
           
        }
    }

    private void EmptySpace(int value)
    {
        if (timeGame < timeToBonus)
            managerCoin.CallCoinGroup(value);
        else
        {
            timeGame = 0;
          Bonus.CallBonus(value);
        }
    }

    private void CheckNextLevel()
    {
        counttoNextLevel++;
        if (counttoNextLevel > 20)
        {
            StatesGame.SetVelocity(1f);
            StatesGame.SetLevel(1);
            levelText.text = "Level 0" + StatesGame.GetLevel();
            counttoNextLevel = 0;
        }
    }

    public void ResetGameManager()
    {
        counttoNextLevel = 1;
        timeGame = 0;
        time = 0;
        obstleManager.ResetAll();
        managerCoin.ResetAll();
        levelText.text = "Level 0" + StatesGame.GetLevel();
    }
}
