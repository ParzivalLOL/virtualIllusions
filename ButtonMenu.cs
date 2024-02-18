using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }
    }
    public void OnPlay() {
        SceneManager.LoadScene("Level1");
    }
    public void onTutorial() {
        if(SceneManager.GetActiveScene().name == "Tutorial") {
        SceneManager.LoadScene("Tutorial Level 1");
        } else {
            SceneManager.LoadScene("Tutorial");
        }
    }
    public void onMenu() {
        SceneManager.LoadScene("Menu");
    }
    public void onNextLevel() {
        if(SceneManager.GetActiveScene().buildIndex <= 7) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void OnQuit() {
        Application.Quit();
    }

}
