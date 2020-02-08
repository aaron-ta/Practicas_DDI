using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pauser : MonoBehaviour {
	private bool paused = false;
	private bool muted = false;
	public GameObject pauseMenu;
	public Button yourButton;
	public Button m_Continue, m_Mute, m_Exit;
	public AudioSource m_MyAudioSource;
	
	void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        m_Continue.onClick.AddListener(ContinueGame);
		m_Mute.onClick.AddListener(MuteAudio);
		m_Exit.onClick.AddListener(Exit);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.P))
		{
			paused = !paused;
			pauseMenu.SetActive(paused);
			Time.timeScale = paused? 0 : 1;
		}
	}
	
	void MuteAudio () {
		muted = !muted;
		if(muted)
			m_MyAudioSource.volume = 0f;
		else
			m_MyAudioSource.volume = 100.0f;
	}

	public void ContinueGame()
	{
		paused = false;
		pauseMenu.SetActive(paused);
		Time.timeScale = 1;
	}

	public void Exit()
	{
		UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
	}
}
