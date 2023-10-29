using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    //インスペクターウィンドウからゲームオブジェクトを設定する
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject overPanel;
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
        startPanel.SetActive(false);
    }

    public void InitToMenu()
    {
        startPanel.SetActive(true);
        overPanel.SetActive(false);
    }
}
