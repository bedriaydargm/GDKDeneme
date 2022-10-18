using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
            DestroyImmediate(this);

        instance = this;
        Application.targetFrameRate = 60;

    }

    [SerializeField] private ObstacleData _obstacleData;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Player _player;
    public GameObject obstaclePrefab;
    [SerializeField] private List<Obstacle> obstacles;

    [Space(20)]
    [SerializeField] private TMP_Text roundScoreText;
    [SerializeField] private TMP_Text maxScoreText;
    [SerializeField] private Canvas endGameCanvas;

    public ObstacleData obstacleData { get { return _obstacleData; } }
    public int score { get { return _score; } }
    public bool isGamePlaying { get; set; }

    private int _score;
    private int _maxScore;

    public void AddScore(int score)
    {
        _score += score;
        ScoreTextUpdate();
    }

    public void GameStart()
    {
        isGamePlaying = true;
        Time.timeScale = 1f;
        _player.Shoot();
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        isGamePlaying = false;
        roundScoreText.text = "Round Score: " + _score.ToString();

        if(_score > _maxScore)
        {
            _maxScore = _score;
            PlayerPrefs.SetInt("maxScoreInt", _maxScore);
        }

        maxScoreText.text = "High Score: " + _maxScore.ToString();
        endGameCanvas.gameObject.SetActive(true);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void AddObstacle(Obstacle obstacle)
    {
        obstacles.Add(obstacle);
    }

    public void RemoveObstacle(Obstacle obstacle)
    {
        obstacles.Remove(obstacle);
        if(obstacles.Count <= 0 && isGamePlaying)
        {
            Instantiate(obstaclePrefab, 1.5f * Vector3.up + Random.Range(-.25f, .25f) * Vector3.right, Quaternion.identity);
        }
    }

    private void ScoreTextUpdate()
    {
        _scoreText.text = _score.ToString();
    }

    private void Start()
    {
        Time.timeScale = 0f;
        _score = 0;
        _maxScore = PlayerPrefs.GetInt("maxScoreInt", 0);
        ScoreTextUpdate();
        Instantiate(obstaclePrefab, 1.5f * Vector3.up, Quaternion.identity);
    }
}
