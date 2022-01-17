using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string lvlName;

        void OnCollisionEnter2D(Collision2D col)//Mudar de level ao final do mesmo
        {
            if (col.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(lvlName);
            }
        }
    
}
