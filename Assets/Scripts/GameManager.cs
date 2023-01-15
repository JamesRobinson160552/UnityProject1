using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject[] enemies;
    private int score;
    private float minHeight = 6.0f;
    private float maxHeight = 16.0f;
    private float spawnRate = 1.4f;
    public bool gameActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void startGame()
    {
        titleScreen.gameObject.SetActive(false);
        gameActive = true;
        StartCoroutine(SpawnEnemy());
        score = 0;
        updateScore(0);
    }

    IEnumerator SpawnEnemy()
    {
        while(gameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int enemyChoice = Random.Range(1, 13);
            if (enemyChoice <= 7)
            {
                float spawnHeight = Random.Range(minHeight, maxHeight);
                Vector3 spawnPosition = new Vector3(20.0f, spawnHeight, -9.0f);
                Instantiate(enemies[0], spawnPosition, enemies[0].transform.rotation);
            }
            else if (enemyChoice <=11)
            {
                Vector3 spawnPosition = new Vector3(20.0f, 7.0f, -9.0f);
                Instantiate(enemies[1], spawnPosition, enemies[1].transform.rotation);
            }
            else if (enemyChoice == 12)
            {
                if (GameObject.Find("EnemyDrone") != null)
                //Only allow one drone at a time
                {
                    float spawnHeight = Random.Range(minHeight, maxHeight);
                    Vector3 spawnPosition = new Vector3(20.0f, spawnHeight, -9.0f);
                    Instantiate(enemies[0], spawnPosition, enemies[0].transform.rotation);
                }
                else
                {
                    Vector3 spawnPosition = new Vector3(20.0f, 11.0f, -9.0f);
                    Instantiate(enemies[2], spawnPosition, enemies[2].transform.rotation);
                }
            }
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
