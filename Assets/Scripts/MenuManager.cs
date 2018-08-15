using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour {

    [SerializeField]
    Button quit, startSingleplayer, startMultiplayer, tutorial;

    [SerializeField]
    string firstSinglePlayerStage, firstMultiPlayerStage, tutorialName;

	// Use this for initialization
	void Start () 
    {
        quit.onClick.AddListener(OnQuit);
        startSingleplayer.onClick.AddListener(StartSinglePlayer);
        startMultiplayer.onClick.AddListener(StartMultiPlayer);
        tutorial.onClick.AddListener(OpenTutorial);

        //Application.targetFrameRate = 120;
	}
	
    void OnQuit () 
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            //hier kommt dann unsere ld jam seite rein zum bewerten
            Application.OpenURL("https://ldjam.com/events/ludum-dare/42/$113741");
        }
        else
        {
            Application.OpenURL("https://ldjam.com/events/ludum-dare/42/$113741");
            Application.Quit();
        }


    }
    void StartSinglePlayer ()
    {
        SceneManager.LoadScene(sceneName: firstSinglePlayerStage);
        
    }
    void StartMultiPlayer()
    {
        SceneManager.LoadScene(sceneName: firstMultiPlayerStage);
    }
    void OpenTutorial()
    {
        SceneManager.LoadScene(sceneName: tutorialName);
    }
	
}
