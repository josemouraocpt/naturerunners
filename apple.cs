using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    public int Score;

    void OnTriggerEnter2D(Collider2D col)//Aumentar a pontuação caso o "Player" toque a maça
    {
        if(col.gameObject.tag == "Player")
        {
            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();
            
            Destroy(gameObject);
        }
    }
}
