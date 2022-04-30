using UnityEngine;

public class Entity : MonoBehaviour
{
    public GameController gameController;
    public HealthController healthController;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    public float speed;

    // Entity type & the corresponding sprite
    public bool isCatch;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite catchSprite, dropSprite;


    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        // Apply corresponding sprite (Catch or Drop)
        if (isCatch) { spriteRenderer.sprite = catchSprite; }
        else { spriteRenderer.sprite = dropSprite; }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, - speed * Time.deltaTime);

        // Make sure Entity is destroyed if somehow collided and remained on top of Player
        if (!boxCollider.isTrigger && transform.position.y >= -4.5f) { Destroy(gameObject); }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Avoid collision between entities
        if (collision.CompareTag("Entity")) { rb.IsSleeping(); return; }
       
        if (collision.CompareTag("Player"))
        {
            // -----------TESTING-----------
            //Debug.Log("PLAYER:" + (collision.transform.position.y + collision.transform.localScale.y * .5f).ToString());
            //Debug.Log("ENTITY:" + (transform.position.y - transform.localScale.y * .5f).ToString());

            // Make sure Physics2D is applied when Entity is not collided with Player at top side
            if (collision.transform.position.y + collision.transform.localScale.y * .5f -.5f > transform.position.y - transform.localScale.y * .5f)
            {
                boxCollider.isTrigger = false;
                return;
            }

            // If Entity is Catch, increment point
            if (isCatch) { gameController.point++; }
            // If Entity is Drop, decrement health
            else { healthController.entityEnter = true; }
            
            Destroy(gameObject);
        }
        else
        {
            // If Entity is Catch, send trigger so HealthController can respond properly
            if (isCatch) { healthController.entityEnter = true; }

            Destroy(gameObject);
        }
    }
}
