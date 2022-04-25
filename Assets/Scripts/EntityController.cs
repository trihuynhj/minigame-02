using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject entityPrefab;

    [SerializeField] private float entitySpeed;

    private Vector3 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3((float)Screen.width, (float)Screen.height, 0f));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { SpawnEntity(); }
    }

    private void SpawnEntity()
    {
        GameObject entity = Instantiate(entityPrefab, transform);
        entity.transform.position = new Vector3(Random.Range(-screenBounds.x + entity.transform.localScale.x * .5f, screenBounds.x - entity.transform.localScale.x * .5f), screenBounds.y + 1f, 0f);

        Entity entityScript = entity.GetComponent<Entity>();
        entityScript.gameController = gameController;
    }
}
