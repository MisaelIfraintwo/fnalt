using UnityEngine;

public class Coin : MonoBehaviour
{
    public int pointsToAdd = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddPoints(pointsToAdd);
            }
            else
            {
                Debug.LogError("nao");
            }
            Destroy(gameObject);
        }
    }
}
