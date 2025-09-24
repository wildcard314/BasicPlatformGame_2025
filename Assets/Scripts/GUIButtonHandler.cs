using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtonHandler : MonoBehaviour
{
    public GameObject menu;
    private bool sceneloaded = false;
    private bool gamepaused = false;

    public void Update()
    {
        showPauseMenu();
    }

    public void loadGame()
    {
        //load level 1
        //when i load this i want the canvas to populate to the new level
        DontDestroyOnLoad(this.gameObject);
        menu.SetActive(false);
        sceneloaded = true;
        SceneManager.LoadScene("SampleScene");
    }

    public void exitGame()
    {
        //this only works in the full build
        Application.Quit();
    }

    private void showPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.P) && sceneloaded)
        {
            if(!gamepaused)
            {
                menu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                menu.SetActive(false);
                Time.timeScale = 1;
                gamepaused = false;
            }
           
        }
    }

}
