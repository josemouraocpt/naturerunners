using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public static GameController instance;
    public Text scoreText;
    public GameObject gameOver;

    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }
    
    public void ShowGameOver()//Mostrar a tela de game over caso ocorra
    {
        gameOver.SetActive(true);
    }

    public void RestarGame(string lvlName)//Reiniciar o level após o game over
    {
        SceneManager.LoadScene(lvlName);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
