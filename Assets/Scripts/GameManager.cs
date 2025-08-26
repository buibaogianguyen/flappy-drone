using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Vector3 newPosition = new Vector3(-0.82f, -0.45f, 4f);
    public DroneController player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public int score;
    public PillarSpawner pillarSpawner;
    public TextMeshProUGUI hiScoreText;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
        gameOver.SetActive(false);
        score = 0;
        scoreText.text = score.ToString();
        hiScoreText.enabled = false;
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        player.transform.position = newPosition;

        Rigidbody2D playerRigidBody = player.GetComponent<Rigidbody2D>();
        playerRigidBody.velocity = Vector2.zero;



        PillarController[] pillars = FindObjectsOfType<PillarController>();

        for (int i = 0; i < pillars.Length; i++)
        {
            pillars[i].transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f, pillars[i].transform.position.y, pillars[i].transform.position.z);
        }

        pillarSpawner.speedIncreasePerFrame = 1f;
        hiScoreText.enabled = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        hiScoreText.enabled = true;
        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    void SetPosition(GameObject playerObject, Vector3 newPosition)
    {
        playerObject.transform.position = newPosition;
    }
}
