using UnityEngine;

public class Entity : MonoBehaviour
{
    public GameController gameController;
    public Health health;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, - speed * Time.deltaTime);

        // Make sure Entity is destroyed if somehow collided and remained on top of Player
        if (!boxCollider.isTrigger && transform.position.y >= -4f) { Destroy(gameObject); }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Entity")) { rb.IsSleeping(); }
        else if (collision.CompareTag("Player"))
        {
            // Make sure Physics2D is applied when Entity is not collided with Player at top side
            if (collision.transform.position.y + collision.transform.localScale.y * .5f - .3f > transform.position.y - transform.localScale.y * .5f)
            {
                boxCollider.isTrigger = false;
                return;
            }

            gameController.point++;
            Destroy(gameObject);
        }
        else
        {
            // Send trigger so Health functions properly
            health.entityEnter = true;
            Destroy(gameObject);
        }
    }
}
