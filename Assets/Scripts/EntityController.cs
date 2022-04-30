using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private HealthController healthController;
    [SerializeField] private GameObject entityPrefab;

    [SerializeField] private float entitySpeed;

    private Vector3 screenBounds;

    private void Start()
    {
        // Calculate playable area
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3((float)Screen.width, (float)Screen.height, 0f));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { SpawnEntity(); }
    }

    private void SpawnEntity()
    {
        GameObject entity = Instantiate(entityPrefab, transform);
        entity.transform.position = new Vector3(Random.Range(-screenBounds.x + gameController.leftBound + entity.transform.localScale.x * .5f, screenBounds.x - entity.transform.localScale.x * .5f), screenBounds.y + 1f, 0f);

        Entity entityScript = entity.GetComponent<Entity>();
        entityScript.gameController = gameController;
        entityScript.healthController = healthController;
        entityScript.speed = entitySpeed;
        entityScript.isCatch = GenerateEntityType();
    }

    // Generate Entity Type of Catch (80%) or Drop (20%)
    private bool GenerateEntityType()
    {
        int odd = Random.Range(0, 100);
        if (odd < 20) { return false; }
        else { return true; }
    }
}
