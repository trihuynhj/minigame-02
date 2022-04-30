using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private HealthController healthController;
    [SerializeField] private GameObject entityPrefab;

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
        entityScript.isCatch = GenerateEntityType();
        entityScript.speed = GenerateEntitySpeed();
    }

    // Generate Entity Type of Catch (80%) or Drop (20%)
    private bool GenerateEntityType()
    {
        int odd = Random.Range(0, 100);
        if (odd < 20) { return false; }
        else { return true; }
    }


    private float GenerateEntitySpeed()
    {
        float entitySpeed = 1f;

        switch(gameController.level)
        {
            case 0:
            case 1:
                entitySpeed = Random.Range(50f, 100f);
                break;

            case 2:
            case 3:
                entitySpeed = Random.Range(100f, 200f);
                break;

            case 4:
            case 5:
                entitySpeed = Random.Range(200f, 400f);
                break;
            
            case 6:
                entitySpeed = Random.Range(300f, 500f);
                break;
        }

        return entitySpeed;
    }
}
