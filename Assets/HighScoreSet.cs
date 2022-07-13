using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreSet : MonoBehaviour
{
    // Start is called before the first frame update
    float highScore;
    TextMeshProUGUI highScoreText;

    private void Awake()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();
        highScore = PlayerPrefs.GetFloat("Record");
    }
    void Start()
    {
        highScoreText.text = "Highscore: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
