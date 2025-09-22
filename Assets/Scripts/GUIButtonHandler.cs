using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtonHandler : MonoBehaviour
{
   public void loadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void exitGame()
    {
        //this only works in the full build
        Application.Quit();
    }

}
