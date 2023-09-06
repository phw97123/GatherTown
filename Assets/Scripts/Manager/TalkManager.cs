using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData(); 
    }

    private void GenerateData()
    {
        talkData.Add(1000, new string[] { "ȭ���� �Դϴ� !!"});
        talkData.Add(2000, new string[] { "�ȳ��ϼ���~ ", "���ú��� A���� �Բ��ϴ� �� ������Ʈ�� ����˴ϴ�!", "���� �ٷ� �������ּ���!" });
        talkData.Add(3000, new string[] { "�ȳ��ϼ���.", "A�� ??? �Դϴ�.", "(���� ģ������ ��...)", "(ȸ�� ��...)", "(ȸ�� ��!)" });
        talkData.Add(4000, new string[] { "�ȳ��ϼ���!", "(������...)", "(�亯��...)", "(�Ϻ��� �����ߴ�!)" }); 

        talkData.Add(100, new string[] { "��ǻ���̴�." }); 
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null; 
        else 
            return talkData[id][talkIndex]; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
