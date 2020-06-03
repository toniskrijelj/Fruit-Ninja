using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
	private static Camera mainCamera;
	public static Camera MainCamera
	{
		get
		{
			if(mainCamera == null)
			{
				mainCamera = Camera.main;
			}
			return mainCamera;
		}
	}

	public static Vector3 GetWorldPosition(Vector3 screenPosition, float z = 0)
	{
		Vector3 position = MainCamera.ScreenToWorldPoint(screenPosition);
		position.z = z;
		return position;
	}

	public static float GetAngleFromVector(Vector3 dir)
	{
		float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		if (n < 0) n += 360;

		return n;
	}

	public static Vector3 GetVectorFromAngle(float angle)
	{
		float angleRad = angle * (Mathf.PI / 180f);
		return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
	}

	public static void SetParticlesRotation(ParticleSystem particles, float rotation, bool play = true)
	{
		var main = particles.main;
		var startRotation = main.startRotation;
		Debug.Log(rotation);
		startRotation.mode = ParticleSystemCurveMode.Constant;
		startRotation.constant = rotation;
		Debug.Log(startRotation.constant);
		main.startRotation = startRotation;
		if (play) particles.Play();
	}

	public static void SetParticlesColor(ParticleSystem particles, Color color, bool play = true)
	{
		var main = particles.main;
		var startColor = main.startColor;
		startColor.color = color;
		main.startColor = startColor;
		if (play) particles.Play();
	}

	public static float SignClamp(float value, float sign, float min, float max)
	{
		if (sign > 0)
		{
			return Mathf.Min(value, max);
		}
		return Mathf.Max(value, min);
	}
}
