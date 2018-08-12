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
    string unentschiedenText = "Both loose!", singlePlayerGameOverText = "Game Over";



    private List<CurserMovement> masters = new List<CurserMovement>();

	// Use this for initialization
	void Start () {
        menu.onClick.AddListener(MenuOnClick);
        next.onClick.AddListener(NextOnClick);
        rematch.onClick.AddListener(RematchOnClick);
        GameObject[] masterObjects = GameObject.FindGameObjectsWithTag("master");
        foreach (GameObject g in masterObjects)
        {
            masters.Add(g.GetComponent<CurserMovement>());
        }
    }

    // Update is called once per frame
	void LateUpdate () {
        

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
                mainUIObject.SetActive(true);
                winText.text = singlePlayerGameOverText; 
            }else 
            {
                mainUIObject.SetActive(true);
                winText.text = unentschiedenText;
            }

        }else if (masters.Count == 1)
        {
            if (!singlePlayer)
            {
                mainUIObject.SetActive(true);
                winText.text = masters[0].winText;
            }

        }
		
	}

    void MenuOnClick () {
        Debug.Log("Menu");
        
    }
    void NextOnClick()
    {
        Debug.Log("Next");
    }
    void RematchOnClick()
    {
        Debug.Log("Rematch");
        int currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(currentSceneNumber);
        SceneManager.LoadScene(sceneBuildIndex: currentSceneNumber);
    }
}
