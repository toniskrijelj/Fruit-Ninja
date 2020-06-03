using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public int score { get; private set; } = 0;
	public int highscore { get; private set; } = 0;

	public event Action<int> OnScoreChanged;
	public event Action<int> OnHighscoreChanged;

	public static Score Instance { get; private set; }

	private TextMeshProUGUI scoreText;
	private TextMeshProUGUI highscoreText;
	private Image icon;

	private float originalIconSize;

	private void Awake()
	{
		Instance = this;
		highscore = PlayerPrefs.GetInt("highscore", 0);
		scoreText = transform.Find("score").GetComponent<TextMeshProUGUI>();
		highscoreText = transform.Find("highscore").GetComponent<TextMeshProUGUI>();
		icon = transform.Find("icon").GetComponent<Image>();
		originalIconSize = icon.rectTransform.localScale.x;
		scoreText.text = "0";
		highscoreText.text = highscore.ToString();
	}

	private void OnDestroy()
	{
		PlayerPrefs.SetInt("highscore", highscore);
	}

	private void OnEnable()
	{
		Fruit.OnSliced += Fruit_OnSliced;
	}

	private void OnDisable()
	{
		Fruit.OnSliced -= Fruit_OnSliced;
	}

	private void Fruit_OnSliced()
	{
		score += 1;
		if (score > highscore)
		{
			highscore = score;
			OnHighscoreChanged?.Invoke(highscore);
			highscoreText.text = highscore.ToString();
			ObjectScaler.Add(highscoreText.transform, 1.2f, 3, () => ObjectScaler.Add(highscoreText.transform.transform, 1f, 3, () => ObjectScaler.Remove(highscoreText.transform)));
		}
		scoreText.text = score.ToString();
		OnScoreChanged?.Invoke(score);
		ObjectScaler.Add(icon.transform, 1.2f, 3, () => ObjectScaler.Add(icon.transform, 1f, 3, () => ObjectScaler.Remove(icon.transform)));
		ObjectScaler.Add(scoreText.transform, 1.2f, 3, () => ObjectScaler.Add(scoreText.transform.transform, 1f, 3, () => ObjectScaler.Remove(scoreText.transform)));
	}

}
