using UnityEngine;

public class HighScoreManager : MonoBehaviour
{

    public GameObject player;
    PlayerControlller pcScript;

    ScoreManagerGui scoreManagerScript;

    private void Start()
    {
        pcScript = GetComponent<PlayerControlller>();
        scoreManagerScript = GetComponent<ScoreManagerGui>();

    }

    public void WriteHighScore()
    {
        //we can write simple things to a standart .txt by using the PlayerPrefs
        PlayerPrefs.SetInt("HighScore1", pcScript.getPlayerHighSCore());

    }

    public int readHighScore() 
    {
        int highScoreFromFile = PlayerPrefs.GetInt("HighScore1", 0);

        return highScoreFromFile;
    }
}
