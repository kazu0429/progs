using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI ResultScoreText;
    public int Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "SCORE\n" + Score.ToString();
    }

    public void ScoreChanger(int score)
    {
        Score += score;
        ScoreText.text = "SCORE\n" + Score.ToString();
        ResultScoreText.text = Score.ToString();
    }
}
