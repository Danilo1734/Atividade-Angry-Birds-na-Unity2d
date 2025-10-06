using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.EventSystems;

public class BirdController : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool isDragging = false;
    private Vector2 startPosition;
    private float maxDistance = 2.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 touchPos = new Vector2(worldPoint.x, worldPoint.y);

            if (touch.phase == TouchPhase.Began)
            {
                if (Vector2.Distance(touchPos, transform.position) < 0.5f)
                    isDragging = true;
            }

            if (isDragging && touch.phase == TouchPhase.Moved)
            {
                Vector2 direction = touchPos - startPosition;
                if (direction.magnitude > maxDistance) direction = direction.normalized * maxDistance;

                transform.position = startPosition + direction;
            }

            if (isDragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
            {
                isDragging = false;
                LaunchBird(startPosition - (Vector2)transform.position);
            }
        }
    }

    void LaunchBird(Vector2 direction)
    {
        rb.isKinematic = false;
        rb.AddForce(direction * 400, ForceMode2D.Force);
        gameObject.AddComponent<BirdCollisionHandler>();
        GameManager.instance.BirdLaunched();
    }
}
