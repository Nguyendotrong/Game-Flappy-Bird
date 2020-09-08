using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    [SerializeField]
    private Button instructionButton; 
    [SerializeField]
    private Text scoreText, bestScoreText, endScoreText; //điểm số
    [SerializeField]
    private GameObject gameOverPanel;
    public static GamePlayController instance; //đồng bộ các biến và các strcipt
    void _makeInstance ()
    {
        if (instance == null)       //khởi tạo
            instance = this;
    }
    void Awake()
    {
        Time.timeScale = 0;
        _makeInstance();

    }
    public void _InstructionButton ()
    {
      
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }

    public void _setScore(int score)
    {
        scoreText.text = "" + score.ToString();
    }
    public void _BirdDiedShowGamePanel()
    {
        gameOverPanel.SetActive(true);
    }
}
