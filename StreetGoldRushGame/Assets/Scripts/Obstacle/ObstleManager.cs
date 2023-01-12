using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstleManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] getObjectObstacle;

    List<Obstacle> obstacleList = new List<Obstacle>();

    int numberCounObstacleGroup;

    

    [SerializeField]
    float[] positionYObstacle;

    void Start()
    {
        getObjectObstacle = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i=0; i < getObjectObstacle.Length; i++)
            obstacleList.Add(getObjectObstacle[i].GetComponent<Obstacle>());

        ResetAll();
    }
    public void CallObstacleGroup(int valueY)
    {

        numberCounObstacleGroup = Random.Range(0, obstacleList.Count-1);  
        obstacleList[numberCounObstacleGroup].Active(positionYObstacle[valueY]);
    }
    public void ResetAll()
    {
        foreach (var item in obstacleList)
        {
            item.transform.SetParent(null);
            item.Disable();
        }
    }
}
