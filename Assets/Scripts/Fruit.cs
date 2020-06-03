using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fruit : MonoBehaviour
{
	public static event Action OnSliced;

	[SerializeField] private CuttedFruit cuttedPrefab = null;
	[SerializeField] private UnityEvent OnCutUnity = null;
	public Action OnCut { private get; set; }

	[SerializeField] private Rigidbody2D rb = null;

	public void Cut(float velocity, float cutRotation)
	{
		OnCut?.Invoke();
		OnCutUnity?.Invoke();

		SpawnCuttedFruit(velocity, cutRotation);
		PlayEffects(velocity, cutRotation);

		OnSliced?.Invoke();

		Destroy(gameObject);
	}

	private void SpawnCuttedFruit(float velocity, float cutRotation)
	{
		CuttedFruit.Spawn(cuttedPrefab, transform.position, cutRotation, velocity);
	}

	private void PlayEffects(float velocity, float rotation)
	{
		BubblesEffect.Create(transform.position, rotation, Color.red);
		CutEffect.Create(transform.position, rotation);
		SplashEffect.Create(transform.position, rotation, velocity, Color.red);
		AudioManager.PlayRandomSplash();
	}

	public Rigidbody2D GetRigidbody()
	{
		return rb;
	}
}
