using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public void LoadMarbleLabyrinth () {
		SceneManager.LoadScene ("MarbleLabyrinth");
	}

	public void LoadIB () 
	{
		SceneManager.LoadScene ("Interstellar Blast");
	}

	public void RestartCurrentScene () 
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void ExitToMainMenu ()
	{
		SceneManager.LoadScene ("Menu");
	}
}
