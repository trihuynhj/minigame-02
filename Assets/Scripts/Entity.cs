using UnityEngine;

public class Entity : MonoBehaviour
{
    public float speed;
    private Vector3 destination;

    private void Start()
    {
        destination = new Vector3(transform.position.x, -20f, 0f);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { Debug.Log("HIT PLAYER"); }
        if (collision.CompareTag("Bound")) { Debug.Log("HIT BOUND"); }

        Destroy(gameObject);
    }
}
