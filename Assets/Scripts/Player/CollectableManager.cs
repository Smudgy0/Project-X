using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public int playerScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collect")
        {
            playerScore += 1;
            Destroy(collision.gameObject);
        }
    }
}
