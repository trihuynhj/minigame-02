using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int[] levels = new int[5]
    {
        10,
        15,
        20,
        30,
        50
    };
    public int level, point, health;

    [SerializeField] private Text levelText;
    [SerializeField] private Text pointText;
    [SerializeField] private Text healthText;

    private void Start()
    {
        level = 0;
        point = 0;
        health = 5;
    }

    private void Update()
    {
        UpdateLevel();

        levelText.text = level.ToString();
        pointText.text = point.ToString();
        healthText.text = health.ToString();
    }

    private void UpdateLevel()
    {
        if (level >= 5) { return; }

        if (point >= levels[level])
        {
            point = 0;
            level++;
        }
    }
}
