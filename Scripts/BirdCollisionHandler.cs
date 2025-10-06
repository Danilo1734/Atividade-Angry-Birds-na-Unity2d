using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{

    private bool hasTouchedGround = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") && !hasTouchedGround)
        {
            hasTouchedGround = true;
            Invoke("DestroyBird", 1.5f);
        }
    }

    void DestroyBird()
    {
        GameManager.instance.BirdLaunched();
        Destroy(gameObject);
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x) > 30f || transform.position.y < -10f)
        {
            GameManager.instance.BirdLaunched();
            Destroy(gameObject);
        }
    }
}
