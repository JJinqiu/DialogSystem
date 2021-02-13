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
    public float textSpeed;

    [Header("头像")] public Sprite face01;
    public Sprite face02;

    private bool m_IsTextFinished;
    private List<string> m_TextList = new List<string>();

    private void Awake()
    {
        GetTextFormFile(textFile);
    }

    private void OnEnable()
    {
        // textLabel.text = m_TextList[index];
        // ++index;
        m_IsTextFinished = true;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && m_IsTextFinished)
        {
            if (index == m_TextList.Count)
            {
                gameObject.SetActive(false);
                index = 0;
                return;
            }

            // textLabel.text = m_TextList[index];
            // ++index;
            StartCoroutine(SetTextUI());
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

    private IEnumerator SetTextUI()
    {
        m_IsTextFinished = false;
        textLabel.text = "";

        switch (m_TextList[index])
        {
            case "A":
                faceImage.sprite = face01;
                ++index;
                break;
            case "B":
                faceImage.sprite = face02;
                ++index;
                break;
        }

        for (var i = 0; i < m_TextList[index].Length; ++i)
        {
            textLabel.text += m_TextList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }

        m_IsTextFinished = true;
        ++index;
    }
}