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

    private void GenerateData() //Talk ������ ���� 
    {
        //Talk
        talkData.Add(1000, new string[] { "�ȳ��ϼ���~", "TIL �ۼ� ���� ������!!" });
        talkData.Add(2000, new string[] { "�ȳ��ϼ���~", "ȭ�����Դϴ�!"});
        talkData.Add(3000, new string[] { "�ȳ��ϼ���.", "(��ȭ�� ������ ����)" });
        talkData.Add(4000, new string[] { "(���� ������ �Ÿ��� ����)" });

        talkData.Add(100, new string[] { "��ǻ���̴�." });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "�ȳ��ϼ���~ ", "���ú��� A���� �Բ��ϴ� �� ������Ʈ�� ����˴ϴ�!", "������ ������ �Ŵ��������� �����ø� �˴ϴ�!" });
        talkData.Add(11 + 2000, new string[] { "�ȳ��ϼ���~", PlayerPrefs.GetString("PlayerName") + "�� A���� ???�� �Դϴ�!" });
        talkData.Add(20 + 3000, new string[] { "�ȳ��ϼ���.", "A�� ??? �Դϴ�.", "(���� ģ������ ��...)", "(ȸ�� ��...)", "(ȸ�� ��!)","(������ ���� �� ������ Ʃ�ʹ����� ���� ��������!)" });
        talkData.Add(30 + 4000, new string[] { "�ȳ��ϼ���!", "(������...)", "(�亯��...)", "(�Ϻ��� �����ߴ�! ��ǻ�ͷ� ���� �۾��� ������!)" });
        talkData.Add(40 + 100, new string[]  { "GitHub ������...","Branch ������...", "�۾���...","Commit,Add �ϴ� ��...","Pull �޾ƿ��� ��...", "Push �ϴ� ��...", "Merge �ϴ���...", "�ݺ�X33","�Ϸ�!", "������ �Ŵ��������� ���� ��������!" });
        talkData.Add(41 + 1000, new string[] { "���� �����̽��ϴ� ~" });
    }

    public string GetTalk(int id, int talkIndex)  //��ȭ ���� ��ȯ 
    {
        //Dictionary�� Key�� �����ϴ��� �˻�
        if(!talkData.ContainsKey(id))
        {   
            if(!talkData.ContainsKey(id))
            {
                //����Ʈ �� ó�� ��絵 ���� �� 
                //�⺻ ��縦 ������ �´�
                return GetTalk(id - id % 100, talkIndex); // ��ȯ���� �ִ� ����Լ��� return ���� �� �Ǿ���
            }
            else
            {
                //�ش� ����Ʈ ���� ���� �� ��簡 ���� �� 
                //����Ʈ �� ó�� ��縦 ������ �´�
                return GetTalk(id - id % 10, talkIndex); 
            }
        }

        if (talkIndex == talkData[id].Length) //talkIndex �� 0���� ����
            return null; 
        else 
            return talkData[id][talkIndex]; 
    }

   
   
}
