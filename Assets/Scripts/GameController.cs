using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // PROGRESSION FIELDS
    public int[] levels;
    public int level, point, health;

    [SerializeField] private Text levelText;
    [SerializeField] private Text pointText;
    [SerializeField] private Text healthText;

    // Accounts for the MetaBar on the left side
    public float leftBound;

    [SerializeField] private LevelPost levelPost;
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
        if (level >= levels.Length) 
        {
            // Edge Case (Final Level)
            progressBar.SetMinMaxValue(levels[level - 1]);
            progressBar.SetValue(levels[level - 1]);
        }
        else 
        {
            progressBar.SetMinMaxValue(levels[level]);
            progressBar.SetValue(point);
        }
        
    }

    private void UpdateLevel()
    {
        // Edge Case (Final Level)
        if (level >= levels.Length) 
        {
            point = levels[level - 1];
            return;
        }

        if (point >= levels[level])
        {
            point = 0;
            level++;

            // Send trigger so other Controllers can respond properly
            healthController.levelUp = true;
            levelPost.levelUp = true;
        }
    }
}
