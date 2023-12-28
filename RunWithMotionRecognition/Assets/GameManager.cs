using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private Human human;

    [SerializeField]
    public PlaneManager planeManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GetPoint()
    {
        human.GetPoint();
    }

    public void MovePlane()
    {
        planeManager.MovePlane();
    }
}
