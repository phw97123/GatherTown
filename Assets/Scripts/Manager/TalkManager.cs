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

    private void GenerateData() //Talk 데이터 저장 
    {
        //Talk
        talkData.Add(1000, new string[] { "안녕하세요~", "TIL 작성 잊지 마세요!!" });
        talkData.Add(2000, new string[] { "안녕하세요~", "화이팅입니다!"});
        talkData.Add(3000, new string[] { "안녕하세요.", "(대화할 주제가 없다)" });
        talkData.Add(4000, new string[] { "(아직 질문할 거리가 없다)" });

        talkData.Add(100, new string[] { "컴퓨터이다." });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "안녕하세요~ ", "오늘부터 A조와 함께하는 팀 프로젝트가 진행됩니다!", "팀편성은 박종민 매니저님한테 들으시면 됩니다!" });
        talkData.Add(11 + 2000, new string[] { "안녕하세요~", PlayerPrefs.GetString("PlayerName") + "은 A조에 ???님 입니다!" });
        talkData.Add(20 + 3000, new string[] { "안녕하세요.", "A조 ??? 입니다.", "(조금 친해지는 중...)", "(회의 중...)", "(회의 끝!)","(하지만 감이 안 잡힌다 튜터님한테 가서 질문하자!)" });
        talkData.Add(30 + 4000, new string[] { "안녕하세요!", "(질문중...)", "(답변중...)", "(완벽히 이해했다! 컴퓨터로 가서 작업을 끝내자!)" });
        talkData.Add(40 + 100, new string[]  { "GitHub 생성중...","Branch 생성중...", "작업중...","Commit,Add 하는 중...","Pull 받아오는 중...", "Push 하는 중...", "Merge 하는중...", "반복X33","완료!", "장윤서 매니저님한테 가서 제출하자!" });
        talkData.Add(41 + 1000, new string[] { "수고 많으셨습니다 ~" });
    }

    public string GetTalk(int id, int talkIndex)  //대화 내용 반환 
    {
        //Dictionary에 Key가 존재하는지 검사
        if(!talkData.ContainsKey(id))
        {   
            if(!talkData.ContainsKey(id))
            {
                //퀘스트 맨 처음 대사도 없을 때 
                //기본 대사를 가지고 온다
                return GetTalk(id - id % 100, talkIndex); // 반환값이 있는 재귀함수는 return 까지 꼭 쎠야함
            }
            else
            {
                //해당 퀘스트 진행 순서 중 대사가 없을 때 
                //퀘스트 맨 처음 대사를 가지고 온다
                return GetTalk(id - id % 10, talkIndex); 
            }
        }

        if (talkIndex == talkData[id].Length) //talkIndex 는 0부터 시작
            return null; 
        else 
            return talkData[id][talkIndex]; 
    }

   
   
}
