using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager; 
    public GameObject talkPanel; 
    public TMP_Text talkText;
    public Text questNameTxt; 
    public GameObject scanObject;

    public bool isAction; //대화 중인지 ? 
    public int talkIndex; //대화데이터의 배열 인덱스

    private void Start()
    {
        questNameTxt.text = questManager.CheckQuest(); 
        //Debug.Log(questManager.CheckQuest()); 
    }
    public void Action(GameObject scanObj) //talkPanel을 보여줌
    {
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }
    void Talk(int id, bool isNpc) //대화 출력
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id); 

        //퀘스트 번호 + NPC Id = 퀘스트 대화 데이터 Id
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        if(talkData == null) //대화가 끝나면
        {
            isAction = false;
            talkIndex = 0; //초기화 
            questNameTxt.text = questManager.CheckQuest(id); 
            return; 
        }

        talkText.text = talkData;

        isAction = true;
        talkIndex++;  
    }
}
