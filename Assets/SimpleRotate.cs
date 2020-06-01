using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
	[SerializeField] private float speed = 360;

    void Update()
    {
		transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
