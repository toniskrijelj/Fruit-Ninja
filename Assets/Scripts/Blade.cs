using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
	[SerializeField] private float minimumDistance = 0.05f;

	public void SetPosition(Vector3 position)
	{
		float distance = (position - transform.position).magnitude;
		if (distance >= minimumDistance)
		{
			var hits = Physics2D.RaycastAll(transform.position, position - transform.position, distance, 1 << 9 | 1 << 13);
			float angle = Utilities.GetAngleFromVector((position - transform.position).normalized);
			float velocity = distance / Time.deltaTime;
			for (int i = 0; i < hits.Length; i++)
			{
				Fruit fruit = hits[i].transform.GetComponent<Fruit>();
				if (fruit != null)
				{
					fruit.Cut(velocity, angle);
				}
				else
				{
					Player.Instance.Miss();
					Player.Instance.Miss();
					Player.Instance.Miss();
				}
			}
		}
		transform.position = position;
	}
}
