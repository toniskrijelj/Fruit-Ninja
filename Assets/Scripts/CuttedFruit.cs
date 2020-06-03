using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttedFruit : MonoBehaviour
{
	public static CuttedFruit Spawn(CuttedFruit prefab, Vector3 worldPosition, float cutRotation, float velocity)
	{
		float multiplier = Mathf.Clamp(velocity / 100, 1f, 2f);
		CuttedFruit fruit = Instantiate(prefab, worldPosition, Quaternion.Euler(0, 0, cutRotation));
		Vector3 forwardOne = fruit.partOne.transform.forward;
		Vector3 forwardTwo = fruit.partTwo.transform.forward;
		fruit.partOne.AddForce(-forwardOne * Random.Range(2f, 4f) * multiplier, ForceMode.Impulse);
		fruit.partTwo.AddForce(-forwardTwo * Random.Range(2f, 4f) * multiplier, ForceMode.Impulse);
		fruit.partOne.AddTorque(Random.Range(0.5f, 2f) * -Mathf.Sign(forwardOne.y), Random.Range(-1f, 1f), Random.Range(-1f, 1f), ForceMode.Impulse);
		fruit.partTwo.AddTorque(Random.Range(0.5f, 2f) * -Mathf.Sign(forwardTwo.y), Random.Range(-1f, 1f), Random.Range(-1f, 1f), ForceMode.Impulse);
		return fruit;
	}

	[SerializeField] Rigidbody partOne = null;
	[SerializeField] Rigidbody partTwo = null;

	private void Awake()
	{

		Destroy(gameObject, 5);
	}
}
