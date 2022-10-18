using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[Serializable]
public class FruitData
{
	[SerializeField] private FruitType fruit = FruitType.Watermelon;
	[SerializeField] private Color colorInside = new Color(1, 1, 1, 1);

	public FruitType Type()
	{
		return fruit;
	}

	public Color Color()
	{
		return colorInside;
	}
}

public class Fruit : BaseFruit
{
	public static List<Fruit> Instances = new List<Fruit>();

	public static event Action<FruitData, SlicedFruit, float, float> OnFruitSliced;
	public static event Action<FruitData, SlicedFruit, float, float> OnFruitCritical;

	public static float criticalChance = 15f;

	[SerializeField] private FruitData data = null;

	private void Awake()
	{
		Instances.Add(this);
	}

	public override void Slice(float velocity, float cutRotation)
	{
		bool critical = Random.Range(1f, 100f) <= criticalChance;
		SlicedFruit sliced = null;
		if (slicedPrefab != null)
		{
			sliced = SlicedFruit.Spawn(slicedPrefab, transform.position, velocity, cutRotation, critical);
		}
		onSliced?.Invoke();
		if(critical)
		{
			OnFruitCritical?.Invoke(data, sliced, velocity, cutRotation);
		}
		else
		{
			OnFruitSliced?.Invoke(data, sliced, velocity, cutRotation);
		}
		Destroy(gameObject);
	}

	private void OnDestroy()
	{
		Instances.Remove(this);
	}

	public FruitData Data()
	{
		return data;
	}

}
