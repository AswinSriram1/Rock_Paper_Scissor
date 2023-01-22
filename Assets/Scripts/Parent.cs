using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Parent : MonoBehaviour
{

    private GameObject childobjects;

    public GameObject gameoverPanel;

    //public TextMeshProUGUI timer;

    public Slider timeSlider;

    public float countdownTime;
    float timeRestart;

    public TextMeshProUGUI timer;

    public GameObject timesUpObj;
    public GameObject nicetryObj;

    public int difficultyLevel;

    [SerializeField] AudioSource[] audios;

    [SerializeField] Image sliderImage;

    [SerializeField] ParticleSystem[] gamePartical;

    

    // Start is called before the first frame update
    void Start()
    {

        

        childobjects = transform.GetChild(Random.Range(0, 3)).gameObject;
        childobjects.SetActive(true);
        //timer.text = "" + timeleft;

        difficultyLevel = Difficulty.instance.difficultyLevel;

        
        //sliderImage.color = slidercolor;
        if (difficultyLevel == 1)
        {
            timeSlider.maxValue = 2.5f;
            countdownTime = 2.5f;
        }

        if (difficultyLevel == 2)
        {
            timeSlider.maxValue = 2.5f;
            countdownTime = 2.5f;
        }
        if (difficultyLevel == 3)
        {
            timeSlider.maxValue = 1.5f;
            countdownTime = 1.5f;
        }

        timeRestart = countdownTime;

        

        StartCoroutine(TimerStart());
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(countdownTime <= 0)
        {
            timer.text = ""+ 0;
            timeSlider.value = countdownTime;
            wrongSelection();
            timesUpObj.SetActive(true);
            nicetryObj.SetActive(false);
        }

        if(countdownTime < 0.7)
        {
            sliderImage.GetComponent<Image>().color = new Color32(156, 0, 0, 255);
        }

    }

    public void selectingSame()
    {        
        GameObject[] childlist = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            childlist[i] = transform.GetChild(i).gameObject;
        foreach (GameObject go in childlist)
            go.SetActive(false);
        childobjects = transform.GetChild(Random.Range(0, 3)).gameObject;
        childobjects.SetActive(true);
        countdownTime = timeRestart;
        sliderImage.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        gamePartical[0].Play();
        gamePartical[1].Play();

    }

    public void correctSelection()
    {
        GameObject[] childlist = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            childlist[i] = transform.GetChild(i).gameObject;
        foreach (GameObject go in childlist)
            go.SetActive(false);
        childobjects = transform.GetChild(Random.Range(0, 3)).gameObject;
        childobjects.SetActive(true);
        ScoreManager.instance.AddPoints();
        countdownTime = timeRestart;
        audios[0].Play();
        sliderImage.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        gamePartical[0].Play();
        gamePartical[1].Play();
    }

    public void wrongSelection()
    {
        GameObject[] childlist = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            childlist[i] = transform.GetChild(i).gameObject;
        foreach (GameObject go in childlist)
            go.SetActive(false);
        gameoverPanel.SetActive(true);
        nicetryObj.SetActive(true);
        audios[1].Play();
        Time.timeScale = 0f;
        

    }
    public void Tryagain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    IEnumerator TimerStart()
    {
        while (countdownTime > 0)
        {
            timer.text = countdownTime.ToString("f2");
            timeSlider.value = countdownTime;
            yield return new WaitForSeconds(0.1f);
            countdownTime -= 0.1f;
        }
    }

}
