using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonGenerator : MonoBehaviour
{
    public GameObject buttonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GenerateButtons(int row,int column)
    {
        GameObject canvas = GameObject.Find("Canvas");
        int[] numbers = Enumerable.Range(1, row * column)
            .OrderBy(i => Guid.NewGuid()).ToArray();

        float offsetCnt_x = (row - 1) / 2.0f;
        float offsetCnt_y = (column - 1) / 2.0f;
        int index = 0;
        for (int x = 0; x < row; x++)
        {
            for (int y = 0; y < column; y++)
            {
                GameObject button = Instantiate(this.buttonPrefab) as GameObject;
                button.GetComponent<ButtonController>().SetNum(numbers[index]);
                index++;
                button.transform.SetParent(canvas.GetComponent<RectTransform>());
                Vector2 w_h = button.GetComponent<RectTransform>().sizeDelta;
                
                button.transform.localPosition = new Vector3((x-offsetCnt_x)*w_h.x,(y-offsetCnt_y)*w_h.y,0);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
