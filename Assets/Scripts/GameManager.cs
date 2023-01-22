using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public TextMeshProUGUI highScore;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject difficultyMenu;
    public int difficultyLvl;


    // Start is called before the first frame update
    void Start()
    {
        if(highScore != null)
        {
            highScore.text = PlayerPrefs.GetInt("highscore").ToString();
        }
        if (difficultyLvl == 0)
        {
            difficultyLvl = 1;
        }

        difficultyLvl = PlayerPrefs.GetInt("DifficultyLvl");

       FindObjectOfType<Difficulty>().difficultyLevel = difficultyLvl;
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<Difficulty>().difficultyLevel = difficultyLvl;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void SelectDifficulty()
    {
        mainMenu.SetActive(false);
        difficultyMenu.SetActive(true);

    }
    public void SelectedDifficulty()
    {
        mainMenu.SetActive(true);
        difficultyMenu.SetActive(false);
    }

    public void Easy()
    {
        PlayerPrefs.SetInt("DifficultyLvl", 1);
        difficultyLvl = PlayerPrefs.GetInt("DifficultyLvl", 1);
    }
    public void Medium()
    {
        PlayerPrefs.SetInt("DifficultyLvl", 2);
        difficultyLvl = PlayerPrefs.GetInt("DifficultyLvl", 2);
    }
    public void Hard()
    {
        PlayerPrefs.SetInt("DifficultyLvl", 3);
        difficultyLvl = PlayerPrefs.GetInt("DifficultyLvl", 3);
    }
}
