using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] Rope_Center;
    [Header("Fx & Sounds")]
    [SerializeField] ParticleSystem[] Effects;
    [SerializeField] private AudioSource[] Sounds;
    [Header("UI Settings")]
    [SerializeField] private GameObject[] Panels;
    [SerializeField] private TextMeshProUGUI[] texts; 
    public int ballNum;
    public int overthrowObjectNum;
    void Start()
    {
        Time.timeScale = 1f;
        foreach (var item in texts)
        {
            item.text = "LEVEL : " + SceneManager.GetActiveScene().buildIndex;
        }
    }
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
            if(hit2D.collider != null)
            {
                if(hit2D.collider.CompareTag("Center1"))
                {
                    //balls[0].HingeControl["Center1"].enabled = false;
                    ChainTechinc(hit2D,"Center1");
                }
                else if(hit2D.collider.CompareTag("Center2"))
                {
                    //balls[0].HingeControl["Center2"].enabled = false;
                    ChainTechinc(hit2D,"Center2");
                }
                else if(hit2D.collider.CompareTag("Center3"))
                {
                    //balls[1].HingeControl["Center3"].enabled = false;
                    ChainTechinc(hit2D,"Center3");
                }
                else if(hit2D.collider.CompareTag("Center4"))
                {
                    //balls[1].HingeControl["Center4"].enabled = false;
                    ChainTechinc(hit2D,"Center4");
                }
            }
            
        }
    }
    void ChainTechinc(RaycastHit2D hit2D,string tag)
    {
        Effects[1].gameObject.SetActive(true);
        Effects[1].gameObject.transform.position = hit2D.collider.transform.position; 
        hit2D.collider.gameObject.SetActive(false);
        foreach (var item in Rope_Center)
        {
            if (item.GetComponent<RopeManagement>().hingeName == tag)
            {
                foreach (var item2 in item.GetComponent<RopeManagement>().linkPool)
                {
                    item2.SetActive(false);
                }
            }
        }
        Sounds[0].Play();
    }
    public void BallFall()
    {
        ballNum--;
        if (ballNum == 0)
        {
            if (overthrowObjectNum > 0)
            {
                //Lose
                Panels[0].SetActive(false);
                Panels[3].SetActive(true);
                Sounds[1].Play();
            }
            else if (overthrowObjectNum == 0)
            {
                //Win
                Panels[0].SetActive(false);
                Panels[2].SetActive(true);
                Sounds[2].Play();
                Effects[0].gameObject.SetActive(true);
            }
        }
        else
        {
            if (overthrowObjectNum == 0)
            {
                //Win
                Panels[0].SetActive(false);
                Panels[2].SetActive(true);
                Sounds[2].Play();
                Effects[0].gameObject.SetActive(true);
            }
        }

    }
    public void ObjectFall()
    {
        overthrowObjectNum--;
        if (ballNum == 0 && overthrowObjectNum == 0)
        {
            //Win
            Panels[0].SetActive(false);
            Panels[2].SetActive(true);
            Sounds[2].Play();
            Effects[0].gameObject.SetActive(true);
        }
        else if (ballNum == 0 && overthrowObjectNum > 0)
        {
            //Lose
            Panels[0].SetActive(false);
            Panels[3].SetActive(true);
            Sounds[1].Play();
        }
    }
    public void ButtonFunc(string status)
    {
        switch(status)
        {
            case "Pause":
                Time.timeScale = 0f;
                Panels[0].SetActive(false);
                Panels[1].SetActive(true);
                break;
            case "TryAgain":
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case "Resume":
                Time.timeScale = 1f;
                Panels[0].SetActive(true);
                Panels[1].SetActive(false);
                break;
            case "NextLevel":
                Time.timeScale =1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            case "Quit":
                Application.Quit();
                break;
        }
    }
}
