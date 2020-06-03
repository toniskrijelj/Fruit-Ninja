using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public void LoadScene(int index)
	{
		var sceneLoading = SceneManager.LoadSceneAsync(index);
		//sceneLoading.allowSceneActivation = true;
	}

	public void LoadScene(string scene)
	{
		var sceneLoading = SceneManager.LoadSceneAsync(scene);
	}
}
