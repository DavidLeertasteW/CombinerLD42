using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    bool singlePlayer = false;
    [SerializeField]
    GameObject mainUIObject;
    [SerializeField]
    Button menu, next, rematch;
    [SerializeField]
    Text winText;
    [SerializeField]
    string unentschiedenText = "Both loose!", singlePlayerGameOverText = "Game Over", singlePlayerSuccessText = "Success";
    [SerializeField]
    string nextScene;

    public bool triggerSinglePlayerSuccess = false;



    private List<CurserMovement> masters = new List<CurserMovement>();

	// Use this for initialization
	void Start () {
        menu.onClick.AddListener(MenuOnClick);
        if (nextScene != ""&& nextScene != "null")
        {
            next.onClick.AddListener(NextOnClick);
        }else 
        {
            next.gameObject.SetActive(false);
        }
        rematch.onClick.AddListener(RematchOnClick);
        GameObject[] masterObjects = GameObject.FindGameObjectsWithTag("master");
        foreach (GameObject g in masterObjects)
        {
            masters.Add(g.GetComponent<CurserMovement>());
        }
    }

    // Update is called once per frame
	void LateUpdate () {
        if(triggerSinglePlayerSuccess)
        {
            Time.timeScale = 0.0f;
            mainUIObject.SetActive(true);
            winText.text = singlePlayerSuccessText;
            return;
        }
        

        if(masters.Count>0){
            int count = masters.Count;
            for (int i = 0; i <= masters.Count-1; i++)
            {
                Debug.Log(masters.Count);
                if(masters[i].pawns == 0)
                {
                    Debug.Log("TryingtoRemoveSomeone");
                    masters.Remove(masters[i]);



                }
            }

        } 
        if (masters.Count <= 0){
            if (singlePlayer)
            {
                Time.timeScale = 0.0f;
                mainUIObject.SetActive(true);
                winText.text = singlePlayerGameOverText; 
            }else 
            {
                Time.timeScale = 0.0f;
                mainUIObject.SetActive(true);
                winText.text = unentschiedenText;
            }

        }else if (masters.Count == 1)
        {
            if (!singlePlayer)
            {
                Time.timeScale = 0.0f;
                mainUIObject.SetActive(true);
                winText.text = masters[0].winText;
            }

        }
		
	}

    void MenuOnClick () 
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
    void NextOnClick()
    {
        Debug.Log("Next");
        SceneManager.LoadScene(sceneName: nextScene);

    }
    void RematchOnClick()
    {
        Debug.Log("Rematch");
        int currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneBuildIndex: currentSceneNumber);
    }
}
