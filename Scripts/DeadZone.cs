using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadZone : MonoBehaviour
{
    public Text scorePlayerText, scoreEnemyText;
    int scorePlayer, scoreEnemy;
    public SceneChanger sceneChanger;
    
    public AudioSource deadAudio;
    private void OnTriggerEnter2D(Collider2D ball)
    {
        if(gameObject.tag == "Izquierdo")
        {
            scoreEnemy++;
            UpdateScoreLabel(scoreEnemyText, scoreEnemy);
        }
        else if(gameObject.tag == "Derecho")
        {
            scorePlayer++;
            UpdateScoreLabel(scorePlayerText, scorePlayer);
        }
        deadAudio.Play();
        CheckScore();
        ball.GetComponent<BallBehaviour>().gameStarted = false;
    }
    private void CheckScore()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        if(scorePlayer >= 3)
        {
            if(escenaActual == 5)
            {
                sceneChanger.ChangeSceneTo("WinInsScene");
            }
            else
            {
                sceneChanger.ChangeSceneTo("WinScene");
            }
        }
        else if(scoreEnemy >= 3)
        {
            sceneChanger.ChangeSceneTo("LostScene");
        }
    }
    private void UpdateScoreLabel(Text label, int score)
    {
        label.text = score.ToString();
    }
}
