  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Text highscoreText; 
    public float highscore;
    void Start()
    {
        // highscoreText.text = "Highscore : "+(int) PlayerPrefs.GetFloat("Highscore");
        
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(){
        SceneManager.LoadScene("SampleScene");
    }
}