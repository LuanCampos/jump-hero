using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
	public static GameOverManager instance;
	
	private GameObject gameOverPanel;
	private Animator gameOverAnim;
	private Button restartButton;
	private Button backButton;
	private Text finalScore;
	private GameObject scoreText;
	private GameObject slider;
	
	void Awake()
	{
		MakeInstance();
		InitializeVariables();
	}

	void MakeInstance()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
	
	public void GameOverShowPanel()
	{
		scoreText.SetActive(false);
		slider.SetActive(false);
		gameOverPanel.SetActive(true);
		finalScore.text = "" + ScoreManager.instance.GetScore();
		gameOverAnim.Play("FadeIn");
	}
	
	void InitializeVariables()
	{
		gameOverPanel = GameObject.Find("Game Over Panel Holder");
		gameOverAnim = gameOverPanel.GetComponent<Animator>();
		restartButton = GameObject.Find("Restart Button").GetComponent<Button>();
		backButton = GameObject.Find("Back Button").GetComponent<Button>();
		restartButton.onClick.AddListener(() => Restart());
		backButton.onClick.AddListener(() => BackToMenu());
		finalScore = GameObject.Find("Final Score").GetComponent<Text>();
		scoreText = GameObject.Find("Score Text");
		slider = GameObject.Find("Slider");
		gameOverPanel.SetActive(false);
	}
	
	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}
	
	public void BackToMenu()
	{
		Application.LoadLevel("MainMenu");
	}
	

}
