using Unity.Mathematics.Geometry;
using UnityEngine;

public class Destructables : MonoBehaviour
{
    public int hitsNeeded = 1;

    public GameObject[] potentialRewards;
    
    public void Hit()
    {
        hitsNeeded--;

        if (hitsNeeded <= 0)
        {
            Reward();
        }
    }

    public void Reward()
    {
        int randomNum = Random.Range(0, potentialRewards.Length);
        GameObject RewardClone = Instantiate(potentialRewards[randomNum], transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(collision);
            Hit();
        }
    }
}
