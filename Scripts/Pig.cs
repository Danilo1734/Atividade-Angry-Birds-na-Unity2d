using UnityEngine;

public class Pig : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 3)
        {
            Destroy(gameObject);
            GameManager.instance.PigDestroyed();
        }
    }
}
