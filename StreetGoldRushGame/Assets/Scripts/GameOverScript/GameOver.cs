using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject windowsGameOver;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    GameObject ButtonConfig;
    [SerializeField]
    GameObject ButtonCredits;

    int coin;
    [SerializeField]
    TextMeshProUGUI coinText;

    [SerializeField]
    AudioSource musicGame;

    [SerializeField]
    Player player;
    public IEnumerator CallWindowGameOver()
    {  
        musicGame.Stop();
        StatesGame.SetActiveGame(false);
        yield return new WaitForSeconds(2.7f);
        windowsGameOver.SetActive(true);
        ButtonConfig.SetActive(false);
        ButtonCredits.SetActive(false);
        StartCoroutine(Counter());
    }
   
    private IEnumerator Counter()
    {
        while (coin < StatesGame.GetCoin())
        {
            coin++;
            coinText.text = coin.ToString();
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void RestartGame()
    {
        coin = 0;
        musicGame.Play();
        windowsGameOver.SetActive(false);
        StatesGame.ResetGame();
        gameManager.ResetGameManager();
        ButtonConfig.SetActive(true);
        ButtonCredits.SetActive(true);
        player.StartGame();
    }
}
