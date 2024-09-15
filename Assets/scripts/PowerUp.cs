using UnityEngine;

// enum for powerup types
public enum PowerUpType
{
    SlowMotion,
    Shield,
    Health,
    Dash,
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType type;
    public float duration = 5f;

    private FallingBlock fallingBlock;

    void Start()
    {
        fallingBlock = GetComponent<FallingBlock>();
    }

    void Update()
    {
        if (!fallingBlock.InFrame)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (type)
            {
                case PowerUpType.SlowMotion:
                    collision.GetComponent<Player>().SlowGame(duration);
                    break;
                case PowerUpType.Shield:
                    collision.GetComponent<Player>().ShieldUp(duration);
                    break;
                case PowerUpType.Health:
                    collision.GetComponent<Player>().Heal();
                    break;
                case PowerUpType.Dash:
                    collision.GetComponent<Player>().Dash();
                    break;
            }
            Destroy(gameObject);
        }
    }

}
