﻿using UnityEngine;
using System.Collections;

public class ClubRack : MonoBehaviour 
{
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    while (Input.GetKey(KeyCode.H))
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.H))
        {
            Destroy(other.gameObject);
            AddScore(1);
        }
    }

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    private int score;

    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
