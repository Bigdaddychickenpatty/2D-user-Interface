using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool IsGameActive = true;
    public int Score = 0;
    public TextMeshProUGUI ScoreText;
    public List<GameObject> Target;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score: " + Score;
        StartCoroutine(SpawnTarget());
    }

    public void UpdateScore(int addToScore)
    {
        Score += addToScore;
        Debug.Log("Score: " + Score.ToString());
        ScoreText.text = "Score " +Score.ToString();
    }

    IEnumerator SpawnTarget()
    {
        while(IsGameActive)
        {
            yield return new WaitForSeconds(1);
            int index = Random.Range(0, Target.Count);
            Instantiate(Target[index]);
        }
        
    }
}
