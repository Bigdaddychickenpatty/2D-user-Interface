using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsGameActive;
    public int Score = 0;
    public float SpawnRate = 1;
    public TextMeshProUGUI ScoreText;
    //public TextMeshProUGUI GameTitleText;
    public TextMeshProUGUI GameOverText;
    //public Button StartButton;
    public GameObject StartScene;
    public Button RestartButton;
    public List<GameObject> Target;

    // Start is called before the first frame update
    void Start()
    {
        IsGameActive = false;
    }

    public void StartGame(int difficulty)
    {
        //GameTitleText.gameObject.SetActive(false);
        //StartButton.gameObject.SetActive(false);
        StartScene.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(true);
        IsGameActive = true;
        ScoreText.text = "Score: " + Score;
        SpawnRate /=difficulty;
        StartCoroutine(SpawnTarget());
    }

    public void UpdateScore(int addToScore)
    {
        Score += addToScore;
        Debug.Log("Score: " + Score.ToString());
        ScoreText.text = "Score " +Score.ToString();
    }

    public void GameOver()
    {
        IsGameActive = false;
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnTarget()
    {
        while(IsGameActive)
        {
            yield return new WaitForSeconds(SpawnRate);
            float xPos = Random.Range(0.0176f, -6.79f);
            float yPos = -2;
            Vector2 spawnPos = new Vector2(xPos, yPos);
            int index = Random.Range(0, Target.Count);
            Instantiate(Target[index], spawnPos, Target [index].transform.rotation);
        }
        
    }
}
