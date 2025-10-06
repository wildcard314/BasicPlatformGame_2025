using TMPro;
using UnityEngine;

public class ScoreManagerGui : MonoBehaviour
{
    public TMP_Text guiCurSCore;
    public TMP_Text guiHighSCore;
    public GameObject player;
    private PlayerControlller pcScript;
    private HighScoreManager hsmScript;


    public void Start()
    {
        pcScript = player.GetComponent<PlayerControlller>();
        hsmScript = GetComponent<HighScoreManager>();
        pcScript.setPlayerHighSCore(hsmScript.readHighScore());
        setGUIcurScore();
    }

    public void setGUIcurScore()
    {
        guiCurSCore.text = "Score: " + pcScript.getPlayerScore().ToString();
        if(isHighScore())
        {
            setGUIhighScore();
            hsmScript.WriteHighScore();
        }
        
    }

    public void setGUIhighScore()
    {    
        guiHighSCore.text = "Highscore: " + pcScript.getPlayerHighSCore().ToString();
    }

    public bool isHighScore()
    {
        if(pcScript.getPlayerHighSCore() < pcScript.getPlayerScore())
        {
            //we have a new high score
            pcScript.setPlayerHighSCore(pcScript.getPlayerScore());



            return true;
        }

        else
        {
            return false;
        }
    }
   
}
