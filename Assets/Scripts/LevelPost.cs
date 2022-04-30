using System.Collections;
using UnityEngine;

public class LevelPost : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private Transform levelBar;

    [HideInInspector] public bool levelUp;
    private float distance = 140f;

    private void Start()
    {

    }

    private void Update()
    {
        if (levelUp && coroutine_Movement == null)
        {
            coroutine_Movement = Movement();
            StartCoroutine(coroutine_Movement);
        }
    }

    private IEnumerator Movement()
    {
        Vector2 destination = new Vector2(transform.localPosition.x, transform.localPosition.y + distance);

        while (Vector3.Distance(transform.localPosition, destination) > .1f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, 50 * Time.deltaTime);
            yield return null;
        }

        levelUp = false;
        coroutine_Movement = null;
    }
    private IEnumerator coroutine_Movement = null;
}
