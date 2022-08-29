using UnityEngine;

public class SnakeService : MonoBehaviour
{
    [SerializeField] private SnakeSO[] snakeSO;

    private int players;

    void Start()
    {
        players = PlayerPrefs.GetInt("PlayingPlayers", 1);
        InstantiateSnake();
    }

    public void InstantiateSnake()
    {
        for(int i = 0; i < players; i++)
        {
            SnakeModel model = new SnakeModel(snakeSO[i]);
            SnakeControllerr snakeController = new SnakeControllerr(model, snakeSO[i]);
        }
        
    }
}
