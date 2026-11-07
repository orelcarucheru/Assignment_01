using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 10; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.coinsCollected += scoreValue;
            }

            if (Spawner.Instance != null)
            {
                Spawner.Instance.AddScore(scoreValue);
            }
            Destroy(gameObject);
        }
    }
}