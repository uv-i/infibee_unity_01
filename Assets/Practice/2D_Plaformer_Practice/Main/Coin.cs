using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Detect if the colliding object is on the "Player" layer
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // 2. Get the PlayerController script from that object
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                // 3. Tell the player script to update the numbers and text
                player.CollectCoin();
            }

            // 4. Destroy this coin
            Destroy(gameObject);
        }
    }
}