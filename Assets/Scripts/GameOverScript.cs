using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverPanel;
    public Text scoreText;
    public Button playAgain;
    ScoreManager scoreManager;
    void Start()
    {
     scoreManager=GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        playAgain.onClick.AddListener(PlayAgain);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
        scoreText.text=scoreManager.scoreText.text;
    }
}
