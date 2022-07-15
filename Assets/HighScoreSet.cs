using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreSet : MonoBehaviour
{
    // Start is called before the first frame update
    float highScore;
    [SerializeField] string record;
    TextMeshProUGUI highScoreText;

    private void Awake()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();
        highScore = PlayerPrefs.GetFloat(record);
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
