using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int points;
    private int upgradeCost = 1;
    private Player playerInstance;
    public Player player;
    public Spawner spawner;
    public GameObject restartButton;
    public GameObject pointsLabel;
    public GameObject costLabel;
    public void EnemyKilled()
    {
        if (spawner.spawning)
        {
            points += 1;
            pointsLabel.GetComponent<TextMeshProUGUI>().text = "Points: " + points;
        }
    }
    public void PlayerKilled()
    {
        restartButton.SetActive(true);
        pointsLabel.SetActive(false);
        costLabel.SetActive(false);

        spawner.spawning = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies) 
        {
            Destroy(enemy, 5);
            enemy.GetComponent<Rigidbody2D>().linearVelocity += new Vector2(7, 15 * (Random.value - 0.5f));
        }

    }
    public void UpgradeFireRate()
    {
        if (points >= upgradeCost)
        {
            points -= upgradeCost;
            upgradeCost *= 2;
            playerInstance.shotDelay /= 1.1f;
            pointsLabel.GetComponent<TextMeshProUGUI>().text = "Points: " + points;
            costLabel.GetComponent<TextMeshProUGUI>().text = "Upgrade Cost: " + upgradeCost;

        }
    }
    public void RestartButtonPressed()
    {
        points = 0;
        upgradeCost = 1;

        pointsLabel.GetComponent<TextMeshProUGUI>().text = "Points: " + points;
        costLabel.GetComponent<TextMeshProUGUI>().text = "Upgrade Cost: " + upgradeCost;
        restartButton.SetActive(false);
        pointsLabel.SetActive(true);
        costLabel.SetActive(true);

        spawner.spawning = true;
        playerInstance = Instantiate(player, gameObject.transform.position,  Quaternion.identity);
    }
}
