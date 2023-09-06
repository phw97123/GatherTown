using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex; // 퀘스트 대화 순서

    Dictionary<int, QuestData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData(); 
    }
    void GenerateData()
    {
        questList.Add(10, new QuestData("팀 프로젝트 안내 받기", new int[] { 1000,2000 }));
        questList.Add(20, new QuestData("A조 ???님과 과제하기", new int[] { 3000 }));
        questList.Add(30, new QuestData("튜터님한테 질문하러 가기", new int[] { 4000 }));
        questList.Add(40, new QuestData("프로젝트 완성해서 장윤서매니저님한테 제출하기", new int[] { 100,1000 }));
        questList.Add(50, new QuestData("퀘스트 올 클리어!", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id) //NPC Id를 받고 퀘스트 번호를 반환
    {
        return questId + questActionIndex; 
    }

    //대화 진행을 위해 퀘스트 대화 순서를 올리는 함수
    public string CheckQuest(int id) //NPC id
    {
        //순서에 맞게 대화 했을 때만 퀘스트 대화 순서를 올림
        if(id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        //퀘스트 대화 순서가 끝에 도달했을 때 퀘스트 번호 증가
        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName; 
    }

    //오버로딩
    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0; 
    }
}
