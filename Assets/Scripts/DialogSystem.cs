using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")] public Text textLabel;
    public Image faceImage;

    [Header("文本文件")] public TextAsset textFile;
    public int index;

    private List<string> m_TextList = new List<string>();
    
    private void Awake()
    {
        GetTextFormFile(textFile);
    }

    private void OnEnable()
    {
        textLabel.text = m_TextList[index];
        ++index;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (index == m_TextList.Count)
            {
                gameObject.SetActive(false);
                index = 0;
                return;
            }
            textLabel.text = m_TextList[index];
            ++index;
        }
    }

    private void GetTextFormFile(TextAsset file)
    {
        m_TextList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            m_TextList.Add(line);
        }
    }
}