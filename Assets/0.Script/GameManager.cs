using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Target> targets;

    private float spawnRate = 1.0f;

    public TMP_Text scoreText;

    public TMP_Text gameOverText;

    public Button restartButton;

    public GameObject titleScreen;

    private int score;

    public bool isGameActive;
    void Start()
    {

    }
    
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score : {score}";
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titleScreen.SetActive(false);
        isGameActive = true;
        score = 0;
        scoreText.gameObject.SetActive(true);
        StartCoroutine(nameof(SpawnTarget));
        UpdateScore(0);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
