using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite Player01, Player02, Player03;

    private float fixedHorizontalPosition;
    private Vector2 screenBounds;

    private void Start()
    {
        // Calculate bounds in terms of World Positions
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3((float)Screen.width, (float)Screen.height, 0f));
        fixedHorizontalPosition = -screenBounds.y + transform.localScale.y * .5f;
    }

    private void Update()
    {
        PlayerMovement();
        PlayerSprite();
    }

    private void PlayerMovement()
    {
        // Calculate Player's position according to Mouse Position
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3((float)mouseWorldPosition.x, fixedHorizontalPosition, 0f);

        // Bound Player to playeable area
        float horizontalBound = screenBounds.x - transform.localScale.x * .5f;
        if (transform.position.x >= horizontalBound) { transform.position = new Vector3(horizontalBound, fixedHorizontalPosition, 0f); }
        if (transform.position.x <= -horizontalBound + gameController.leftBound) { transform.position = new Vector3(-horizontalBound + gameController.leftBound, fixedHorizontalPosition, 0f); }
    }

    // More elongated sprite (x scale) to alleviate the difficulty
    private void PlayerSprite()
    {
        switch (gameController.level)
        {
            case 0:
            case 1:
                spriteRenderer.sprite = Player01;
                transform.localScale = new Vector3(1f, transform.localScale.y, 0f);
                break;

            case 2:
            case 3:
                spriteRenderer.sprite = Player02;
                transform.localScale = new Vector3(1.5f, transform.localScale.y, 0f);
                break;

            case 4:
            case 5:
                spriteRenderer.sprite = Player03;
                transform.localScale = new Vector3(2f, transform.localScale.y, 0f);
                break;
        }
    }
}
