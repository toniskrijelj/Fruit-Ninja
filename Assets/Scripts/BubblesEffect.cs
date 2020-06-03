using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesEffect : MonoBehaviour
{
	public static void Create(Vector3 spawnPosition, Vector3 direction, Color color)
	{
		Create(spawnPosition, Utilities.GetAngleFromVector(direction), color);
	}

	public static void Create(Vector3 spawnPosition, float rotation, Color color)
	{
		BubblesEffect bubbles = Instantiate(GameAssets.i.smallBubbles, spawnPosition, Quaternion.Euler(0, 0, rotation));
		Utilities.SetParticlesColor(bubbles.bubbles, color, false);
		bubbles.Play();
		Destroy(bubbles.gameObject, 1.1f);

		bubbles = Instantiate(GameAssets.i.bigBubbles, spawnPosition, Quaternion.Euler(0, 0, rotation));
		Utilities.SetParticlesColor(bubbles.bubbles, color, false);
		bubbles.Play();
		Destroy(bubbles.gameObject, 1.1f);
	}

	[SerializeField] private ParticleSystem bubbles = null;
	[SerializeField] private ParticleSystem glow = null;

	public void Play()
	{
		bubbles.Play();
		glow.Play();
	}
}
