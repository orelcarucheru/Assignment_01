using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    public GameObject[] coinPrefabs;
    public int numberOfCoins = 5;
    public int targetScore = 1000;
    private int currentScore = 0;
    
    private bool isReady = false;

    public float minX = -7f;
    public float maxX = 7f;
    public float minY = -4f;
    public float maxY = 4f;

    void Start()
    {
        Instance = this;
        SpawnCoinsBatch();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        if (currentScore >= targetScore)
        {
            Debug.Log("you won");
        }
    }

    void Update()
    {
        if (!isReady) return;

        GameObject[] remainingCoins = GameObject.FindGameObjectsWithTag("Coin");
        
        if (remainingCoins.Length == 0)
        {
            SpawnCoinsBatch();
        }
    }

    void SpawnCoinsBatch()
    {
        isReady = false;
        for (int i = 0; i < numberOfCoins; i++)
        {
            int randomIndex = Random.Range(0, coinPrefabs.Length);
            GameObject selectedPrefab = coinPrefabs[randomIndex];

            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector2 randomPos = new Vector2(randomX, randomY);
            
            Instantiate(selectedPrefab, randomPos, Quaternion.identity);
        }

        isReady = true;
    }
}