using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	public Dropdown resDropdown;

	Resolution[] resolutions;

	void Start ()
	{
		resolutions = Screen.resolutions;

		resDropdown.ClearOptions ();

		List<string> options = new List<string> ();

		int currentResIndex = 0;
		for (int i = 0; i < resolutions.Length; i++) {
			string option = resolutions [i].width + " x " + resolutions [i].height;
			options.Add (option);

			if (resolutions[i].width == Screen.currentResolution.width
				&& resolutions[i].height == Screen.currentResolution.height) {
				currentResIndex = i;
			}
		}

		resDropdown.AddOptions (options);
		resDropdown.value = currentResIndex;
		resDropdown.RefreshShownValue ();
	}

	public void SetVolume(float v) 
	{
		audioMixer.SetFloat ("volume", v);
	}

	public void SetGraphics(int graphicsIndex)
	{
		QualitySettings.SetQualityLevel (graphicsIndex);
	}

	public void SetFullscreen(bool fscreen)
	{
		Screen.fullScreen = fscreen;
	}

	public void SetRes(int resIndex)
	{
		Resolution res = resolutions [resIndex];

		Screen.SetResolution (res.width, res.height, Screen.fullScreen);
	}
}
