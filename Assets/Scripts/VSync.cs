using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSync : MonoBehaviour
{
	private void Awake()
	{
		Application.targetFrameRate = 144;
		QualitySettings.vSyncCount = 0;
	}
}