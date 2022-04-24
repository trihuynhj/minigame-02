using UnityEngine;

public class Entity : MonoBehaviour
{
    public GameController gameController;

    private BoxCollider2D boxCollider;
    public float speed;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, 0f);
    }

    
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
}
