using UnityEngine;

public class Entity : MonoBehaviour
{
    public GameController gameController;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Entity") { rb.IsSleeping(); }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("COLLIDED WITH PLAYER");
            // Set the collision so that Player only scores if catching Entity at top-side
            if ((transform.position.y - transform.localScale.y * .5f) > (collision.transform.position.y + collision.transform.position.y * .5f))
            {
                gameController.point++;
                Destroy(gameObject);
            }
        }
        else
        {
            gameController.health--;
            Destroy(gameObject);
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.y + collision.transform.localScale.y * .5f - .5f > transform.position.y - transform.localScale.y * .5f)
            {
                boxCollider.isTrigger = false;
                return;
            }

            gameController.point++;
            Destroy(gameObject);
        }
        if (collision.CompareTag("Bound"))
        {
            gameController.health--;
            Destroy(gameObject);
        }
    }
    */
}
