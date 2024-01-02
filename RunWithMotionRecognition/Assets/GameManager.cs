using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager       instance;

    [SerializeField]
    private Human                   human;

    public PlaneManager             planeManager;
    public ObstacleManager          obstacleManager;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    /*
     * public functions
    */
    public void GetPoint()
    {
        human.GetPoint();
    }

    public void MovePlane()
    {
        planeManager.MovePlane();
    }

    public void GameOver()
    {
        human.Die();
    }
}
