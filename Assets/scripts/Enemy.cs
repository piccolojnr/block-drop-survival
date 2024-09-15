using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 0.1f;
    private MeterSpawner meterSpawner;
    private Score score;

    private FallingBlock fallingBlock;

    private void Start()
    {
        meterSpawner = FindObjectOfType<MeterSpawner>();
        score = FindObjectOfType<Score>();
        fallingBlock = GetComponent<FallingBlock>();
    }

    void Update()
    {
        if (!fallingBlock.InFrame)
        {
            score.AddScore(10);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!other.GetComponent<Player>().IsShielded)
            {
                meterSpawner.AddToMeter(MeterType.Health, -damage);
                if (meterSpawner.GetMeterValue(MeterType.Health) <= 0)
                {
                    Die();
                }
            }
            else
            {
                score.AddScore(10);
            }
            Destroy(gameObject);
        }
    }

    void Die()
    {
        Debug.Log("Player died");
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
}