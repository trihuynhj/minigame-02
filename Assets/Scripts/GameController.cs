using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // PROGRESSION FIELDS
    private int[] levels = new int[5]
    {
        30,
        50,
        120,
        300,
        500
    };
    public int level, point, health;

    [SerializeField] private Text levelText;
    [SerializeField] private Text pointText;
    [SerializeField] private Text healthText;

    // Accounts for the MetaBar on the left side
    public float leftBound;

    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private HealthController healthController;

    private void Start()
    {
        level = 0;
        point = 0;
        health = 10;
    }

    private void Update()
    {
        UpdateLevel();

        levelText.text = level.ToString();
        pointText.text = point.ToString();
        healthText.text = health.ToString();

        // Update ProgressBar
        progressBar.SetMinMaxValue(levels[level]);
        progressBar.SetValue(point);
    }

    private void UpdateLevel()
    {
        if (level >= 5) { return; }

        if (point >= levels[level])
        {
            point = 0;
            level++;

            // Send trigger so Health functions properly
            healthController.levelUp = true;
        }
    }
}
