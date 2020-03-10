using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{
    int num;
    GameDirector director;
    float change_speed = 0.01f;
    
    // Start is called before the first frame update
    void Start()
    {

        this.director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        

    }

    public void SetNum(int num)
    {
        this.num = num;
        SetText(num.ToString());
    }
    public void SetText(string s)
    {
        this.GetComponentInChildren<Text>().text = s;
    }

    // Update is called once per frame
    void Update()
    {
        Color c = GetComponentInChildren<Text>().color;
        float next_a = c.a - change_speed;
        Debug.Log(next_a);
        if(next_a < 0)
        {
            next_a = 0;
        }
        GetComponentInChildren<Text>().color = new Color(0, 0 , 0 , next_a);


    }
    public void OnClick1()
    {
        
        if (director.CheckNumber(this.num))
        {
            director.ChangeNextValue();
            Destroy(gameObject);
        }
        else
        {
            director.TouchWrongNum();
        }
        //Color c = GetComponentInChildren<Text>().color;
        //GetComponentInChildren<Text>().color = new Color(c.r, c.g, c.b, 1);
    }
}
