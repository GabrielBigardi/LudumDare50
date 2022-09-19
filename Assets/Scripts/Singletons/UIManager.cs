using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	[SerializeField] private GameObject _lifeText;
	[SerializeField] private Image _fadeImage;
	[SerializeField] private TMP_Text _timeText;

	private void OnEnable()
    {
		PlayerHealth.PlayerLifeChanged += RefreshLifeText;
		HouseInteractable.Interacted += HandlePlayerInteractions;
		TimeManager.GameTimeChanged += OnGameTimeChanged;
	}

    private void OnDisable()
    {
		PlayerHealth.PlayerLifeChanged -= RefreshLifeText;
		HouseInteractable.Interacted -= HandlePlayerInteractions;
		TimeManager.GameTimeChanged -= OnGameTimeChanged;
	}

	private void OnGameTimeChanged(int hour, int minutes, int seconds) => _timeText.SetText($"{hour.ToString("00")} {minutes.ToString("00")} {seconds.ToString("00")}");

	private void Start()
    {
		_fadeImage.color = Color.black;
		_fadeImage.DOColor(Color.clear, 1f);

		Debug.Log(new Color().FromHex("#ff0000"));
	}

	public void RefreshLifeText(int newLifes)
	{
		_lifeText.SetTextOutline(newLifes.ToString());
	}

	private void HandlePlayerInteractions()
	{
		EnterHouse();
	}

	public void EnterHouse()
    {
		var activeScene = SceneManager.GetActiveScene().buildIndex;
		_fadeImage.DOColor(Color.black, 1f).OnComplete(() => _fadeImage.DOColor(Color.clear, 1f));
    }
}
