using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject player;
    public GameObject StartGameScreen;
    public GameObject WinScreen;
    public GameObject ExitScreen;
    public float respawnDelay;
    private int BinkScore;
    private int BlueScore;
    private int WhiteScore;
    public Text BinkText;
    public Text BlueText;
    public Text WhiteText;
    public Text LifeText;
    public int LevelOneCounter;
    bool levelTwo;
    int PlayerLife = 3;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerController>().OnPlayerDeath +=OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ExitScreen.active)
            {
                ExitScreen.SetActive(false);
            }
            else
            {
                StartGameScreen.SetActive(false);
                GameOverScreen.SetActive(false);
                WinScreen.SetActive(false);
                ExitScreen.SetActive(true);
            }
        }

        if (StartGameScreen.active || WinScreen.active)
        {
            player.SetActive(false);
        }
    }

    public void BinkCounter(int nOfFlowers)
    {
        BinkScore += nOfFlowers;
        BinkText.text = ("" + BinkScore);
        Debug.Log(BinkScore);
        if (chickWinning()) OnWin();
    }
    public void BlueCounter(int nOfFlowers)
    {
        BlueScore += nOfFlowers;
        BlueText.text = ("" + BlueScore);
        Debug.Log(BlueScore);
        if (chickWinning()) OnWin();
    }
    public void WhiteCounter(int nOfFlowers)
    {
        WhiteScore += nOfFlowers;
        WhiteText.text = ("" + WhiteScore);
        Debug.Log(WhiteScore);
        if (chickWinning()) OnWin();
    }
    private bool chickWinning()
    {
        if ((WhiteScore >= LevelOneCounter) && (BinkScore >= LevelOneCounter) && (BlueScore >= LevelOneCounter))
        {
            return true; 
        }
        return false;
    }
    public int LifeCounter()
    {
        PlayerLife--;
        LifeText.text = ("" + PlayerLife);
        return PlayerLife;
        
       
    }
    void OnGameOver()
    {
        GameOverScreen.SetActive(true);

        BlueScore = 0;
        BinkScore = 0;
        WhiteScore = 0;
        PlayerLife = 3;
    }

    public void OnClickButton()
    {
        BinkText.text = ("" + BinkScore);
        BlueText.text = ("" + BlueScore);
        WhiteText.text = ("" + WhiteScore);
        LifeText.text = ("" + PlayerLife);
        player.SetActive(true);
        StartGameScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        WinScreen.SetActive(false);

    }
    void OnWin()
    {
        if (!levelTwo)
        {
            WinScreen.SetActive(true);
            BlueScore = BlueScore - LevelOneCounter;
            BinkScore = BinkScore - LevelOneCounter;
            WhiteScore = WhiteScore - LevelOneCounter;
            PlayerLife = 3;
            levelTwo = true;
        }
    }
    public void OnExit()
    {
        Application.Quit();
    }
}

