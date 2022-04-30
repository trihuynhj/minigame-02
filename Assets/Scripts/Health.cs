using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    private List<GameObject> hearts = new List<GameObject>();
    public bool entityEnter;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            hearts.Add(transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        if (entityEnter && gameController.health > 0)
        {
            hearts[gameController.health - 1].SetActive(false);
            gameController.health--;

            entityEnter = false;
        }
    }
}
