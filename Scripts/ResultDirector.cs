using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultDirector : MonoBehaviour
{
    float time;
    GameObject resultText;


    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("GameDirector");
        this.time = g.GetComponent<GameDirector>().time;
        Destroy(g);

        resultText = GameObject.Find("ResultText");
        resultText.GetComponent<Text>().text = "Your Time: " + time.ToString("F1") + "second";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
