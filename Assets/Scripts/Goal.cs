using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    [SerializeField] bool isPlayer1Goal;
    private int player1Score = 0;
    private int player2Score = 0;
    [SerializeField] GameObject wonObj;
    [SerializeField] TMP_Text wonText;
    [SerializeField] TMP_Text player1ScoreText;
    [SerializeField] TMP_Text player2ScoreText;

    [SerializeField] BallMovement ball;

    [SerializeField] Transform player1Pos;
    [SerializeField] Transform player2Pos;

    private void Start() {
        ball = FindAnyObjectByType<BallMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            if (!isPlayer1Goal) {
                player1Score++;
                player1ScoreText.text = player1Score.ToString();
                if (player1Score == 10) {
                    wonText.text = "Player 1 Won";
                    wonObj.SetActive(true);
                    Time.timeScale = 0f;
                    //ReloadGame();
                }
                StartCoroutine(RestartOnGoal());
                ball.Launch();
            }
            else {
                player2Score++;
                player2ScoreText.text = player2Score.ToString();
                if (player2Score == 10) {
                    wonText.text = "Player 2 Won";
                    wonObj.SetActive(false);
                    Time.timeScale = 0f;
                    //ReloadGame();
                }
                StartCoroutine(RestartOnGoal());
                ball.Launch();
            }
        }
    }

    IEnumerator RestartOnGoal() {
        yield return new WaitForSeconds(1);
        player1Pos.position = new Vector3(-13.5f, 0, 0);
        player2Pos.position = new Vector3(13.5f, 0, 0);
        ball.transform.position = new Vector3(0, 0, 0);
    }

    private void ReloadGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
