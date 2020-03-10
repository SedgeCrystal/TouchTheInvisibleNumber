using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    
    int nextNum = 1;
    int raw = 4;
    int column = 4;
    int max;
    float penelty = 5.0f;
    public float time;
    bool isStart;

    GameObject generator;
    GameObject timerText;
    GameObject canvas;
    

    Text startCntText;
    

    public GameObject penaltyTextPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        this.time = -3;
        this.timerText = GameObject.Find("Time");
        this.timerText.GetComponent<Text>().text = 0.ToString("F1");
        this.canvas = GameObject.Find("Canvas");
        this.startCntText = GameObject.Find("StartCountText").GetComponent<Text>();
        this.isStart = false;
        
        generator = GameObject.Find("ButtonGenerator");
       
        max = raw* column;

        DontDestroyOnLoad(this);

        
    }
    
    public void TouchWrongNum()
    {
        this.time +=this.penelty;
        GameObject penalty = Instantiate(penaltyTextPrefab);
        penalty.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(),false);
        Button[] buttons = canvas.GetComponentsInChildren<Button>();
        for (int i =0; i <buttons.Length;i++)
        {
            buttons[i].GetComponentInChildren<Text>().color = new Color(0, 0, 0, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;
        if (this.time < 0)
        {
            startCntText.text = (-1 * time + 0.5).ToString("F0");
        }
        else
        {
            if (!isStart)
            {
                startCntText.text = "";
                generator.GetComponent<ButtonGenerator>().GenerateButtons(raw, column);
                isStart = true;
            }

            if (nextNum <= max)
            {

                this.timerText.GetComponent<Text>().text = this.time.ToString("F1");

            }
            else
            {
                SceneManager.LoadScene("ResultScene");
            }
        }


       
    }
        

    public bool CheckNumber(int number)
    {
        return number == this.nextNum;
    }

    // 次の値を更新する
    public void ChangeNextValue()
    {
        this.nextNum++;
    }



}
