using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager; 
    public GameObject talkPanel; 
    public TMP_Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex; 
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }
    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null) //��ȭ�� ������
        {
            isAction = false;
            talkIndex = 0; //�ʱ�ȭ 
            return; 
        }

        if(isNpc)
        {
            talkText.text = talkData; 
        }
        else
        {
            talkText.text = talkData; 
        }

        isAction = true;
        talkIndex++; 
    }
}
