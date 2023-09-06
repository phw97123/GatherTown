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
        talkData.Add(1000, new string[] { "화이팅 입니다 !!"});
        talkData.Add(2000, new string[] { "안녕하세요~ ", "오늘부터 A조와 함께하는 팀 프로젝트가 진행됩니다!", "지금 바로 시작해주세요!" });
        talkData.Add(3000, new string[] { "안녕하세요.", "A조 ??? 입니다.", "(조금 친해지는 중...)", "(회의 중...)", "(회의 끝!)" });
        talkData.Add(4000, new string[] { "안녕하세요!", "(질문중...)", "(답변중...)", "(완벽히 이해했다!)" }); 

        talkData.Add(100, new string[] { "컴퓨터이다." }); 
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
