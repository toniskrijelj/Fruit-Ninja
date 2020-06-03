using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
	[SerializeField] private float speedMin = 360;
	[SerializeField] private float speedMax = 360;

	private float speed;

	private void Awake()
	{
		speed = Random.Range(speedMin, speedMax);
	}

	void Update()
    {
		transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
