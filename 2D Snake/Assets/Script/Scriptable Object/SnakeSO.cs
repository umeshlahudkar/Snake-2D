using UnityEngine;

[CreateAssetMenu(fileName = "SnakeSO" , menuName = "Snake SO")]
public class SnakeSO : ScriptableObject
{
    public SnakeView snakeView;
    public GameObject snakeSigment;
    public int shieldActiveTime;
    public float spwanOffset;
    public int consumeCountToActivateShield;
    public int consumeCountToRespwanFood;

}
