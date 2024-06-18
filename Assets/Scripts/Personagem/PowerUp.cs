using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int healAmount = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        Gilmar player = other.GetComponent<Gilmar>();
        if (player != null)
        {
            print("peguei vida");
            player.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
