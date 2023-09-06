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

    public bool isAction; //��ȭ ������ ? 
    public int talkIndex; //��ȭ�������� �迭 �ε���

    private void Start()
    {
        questNameTxt.text = questManager.CheckQuest(); 
        //Debug.Log(questManager.CheckQuest()); 
    }
    public void Action(GameObject scanObj) //talkPanel�� ������
    {
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }
    void Talk(int id, bool isNpc) //��ȭ ���
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id); 

        //����Ʈ ��ȣ + NPC Id = ����Ʈ ��ȭ ������ Id
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        if(talkData == null) //��ȭ�� ������
        {
            isAction = false;
            talkIndex = 0; //�ʱ�ȭ 
            questNameTxt.text = questManager.CheckQuest(id); 
            return; 
        }

        talkText.text = talkData;

        isAction = true;
        talkIndex++;  
    }
}
