using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameAssets : MonoBehaviour
{
	private static GameAssets _i;
	public static GameAssets i
	{
		get
		{
			if (_i == null)
			{
				_i = Resources.Load<GameAssets>("GameAssets");
			}
			return _i;
		}
	}

	public Blade blade;
	public BubblesEffect bigBubbles;
	public BubblesEffect smallBubbles;
	public ParticleSystem cut;
	public ParticleSystem splash;
	public ParticleSystem forwardSplash;
	public Fruit watermelon;
	public AudioClip splashSound1;
	public AudioClip splashSound2;
	public AudioClip splashSound3;
	public TMP_FontAsset xBlue;
	public TMP_FontAsset xRed;
}
