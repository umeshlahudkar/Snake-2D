using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeModel 
{
    public GameObject snakeSegment { get; private set; }
    public int foodConsumeCount { get; set; }
    public int massBurnerFoodCount { get; set; }
    public int shieldActiveTime { get; private set; }
    public float spwanOffset { get; private set; }
    public int consumeCountToActivateShield { get; private set; }
    public int consumeCountToSpwanFood { get; private set; }
    public float score { get;  set; }

    public List<GameObject> snakeSegments = new List<GameObject>();

    public SnakeModel(SnakeSO snakeSO)
    {
        snakeSegment = snakeSO.snakeSigment;
        shieldActiveTime = snakeSO.shieldActiveTime;
        spwanOffset = snakeSO.spwanOffset;
        consumeCountToActivateShield = snakeSO.consumeCountToActivateShield;
        consumeCountToSpwanFood = snakeSO.consumeCountToRespwanFood;
    }
}
