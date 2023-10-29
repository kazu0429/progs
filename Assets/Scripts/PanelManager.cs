using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    //インスペクターウィンドウからゲームオブジェクトを設定する
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject overPanel;

    public static string gameStatus;
    // Start is called before the first frame update
    void Start()
    {
        InitToMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        gameStatus = "Play";
        startPanel.SetActive(false);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        gameStatus = "Over";
        overPanel.SetActive(true);
    }

    public void InitToMenu()
    {
        gameStatus = "startable";
        startPanel.SetActive(true);
        overPanel.SetActive(false);
    }
}
