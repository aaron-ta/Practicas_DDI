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
	public GameObject Player;

	void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        m_Continue.onClick.AddListener(ContinueGame);
		m_Mute.onClick.AddListener(MuteAudio);
		m_Exit.onClick.AddListener(Exit);
		Cursor.visible = true;
    }

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.P))
		{
			OnGUI();
			paused = !paused;
			pauseMenu.SetActive(paused);
			Time.timeScale = paused? 0 : 1;
		}
	}
	
	void OnGUI()
	{
		/* 
		if(paused){
    		Cursor.visible = true;
    		Cursor.lockState = CursorLockMode.None;
		}else{
			Cursor.visible = false;
    		Cursor.lockState = CursorLockMode.Locked;
		}
		*/
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
