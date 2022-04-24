using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float fY;
    private Vector2 screenBounds;

    private void Start()
    {
        // Calculate bounds in terms of World Positions
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3((float)Screen.width, (float)Screen.height, 0f));
        fY = -screenBounds.y + transform.localScale.y * .5f;
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3((float)mouseWorldPosition.x, fY, 0f);

        float horizontalBound = screenBounds.x - transform.localScale.x * .5f;
        if (transform.position.x >= horizontalBound) { transform.position = new Vector3(horizontalBound, fY, 0f); }
        if (transform.position.x <= -horizontalBound) { transform.position = new Vector3(-horizontalBound, fY, 0f); }
    }
}
