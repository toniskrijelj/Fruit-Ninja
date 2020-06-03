using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashEffect : MonoBehaviour
{
	public static void Create(Vector3 spawnPosition, float rotation, float velocity, Color color)
	{
		if(velocity >= 40)
		{
			var forwardSplash = Instantiate(GameAssets.i.forwardSplash, spawnPosition, Quaternion.Euler(0, 0, rotation));
			Utilities.SetParticlesColor(forwardSplash, color);
		}
		Utilities.SetParticlesColor(Instantiate(GameAssets.i.splash, spawnPosition, Quaternion.identity), color);
	}
}
