using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeService : MonoBehaviour
{
    [SerializeField] SnakeSO snakeSO;

    void Start()
    {
        InstantiateSnake();
    }

    public void InstantiateSnake()
    {
        SnakeModel model = new SnakeModel(snakeSO);
        SnakeControllerr snakeController = new SnakeControllerr(model,snakeSO);
    }

 
}   
   