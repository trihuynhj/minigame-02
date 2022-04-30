using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [HideInInspector] public bool entityEnter, levelUp;

    private List<GameObject> hearts = new List<GameObject>();

    private void Start()
    {
        // Reference all child objects (Heart)
        for (int i = 0; i < transform.childCount; i++)
        {
            hearts.Add(transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        // Enity is dropped to BottomBound (losing 1 heart)
        if (entityEnter && gameController.health > 0)
        {
            hearts[gameController.health - 1].SetActive(false);
            gameController.health--;

            entityEnter = false;
        }

        // Level-up (gaining 1 extra heart)
        if (levelUp && gameController.health < 10)
        {
            hearts[gameController.health].SetActive(true);
            gameController.health++;

            levelUp = false;
        }
    }
}
