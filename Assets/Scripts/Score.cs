using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    private float score = 0.0f;
    private int difficultyLevel = 1;
    private int scoreToNextLevel = 10;
    private int maxDifficultyLevel = 10;
    public Text ScoreText;
    private bool isDead = false;
    public DeathMenu deathMenu;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)return;
        if(score >= scoreToNextLevel)LevelUp();
        score +=Time.deltaTime*difficultyLevel;
        ScoreText.text = ((int)score).ToString();
    }
    void LevelUp(){
        if(difficultyLevel == maxDifficultyLevel) return;
        scoreToNextLevel *=2;
        difficultyLevel++;
        GetComponent<Player>().SetSpeed(difficultyLevel);
    }

    public void OnDeath(){
        isDead=true;
        if(score >PlayerPrefs.GetFloat("Highscore")){
            PlayerPrefs.SetFloat("Highscore",score);
        }
        deathMenu.ToggleEndScore(score);

    }
}