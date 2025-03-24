using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<Target> targets;

    private float spawnRate = 1.0f;

    public TMP_Text scoreText;

    private int score;

    void Start()
    {
        StartCoroutine(nameof(SpawnTarget));
        score = 0;
        UpdateScore(score);
    }
    
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (true)
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
}
