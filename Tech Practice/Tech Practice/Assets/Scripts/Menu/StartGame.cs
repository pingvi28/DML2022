using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // ��� ���������� ������� ������ ����� �������
    public VectorValue pos;
    // ��� �������� � ������� �����
    public FlagTrigger flag;
    // ����� ����� ����� ���������� ����� ��������
    public TextNumber num;
    public TextNumber num2;
    // ����� �����
    public SceneChangeNumder scCh;

    public void Awake() 
    {
        num.SetNewCount();
        num2.SetNewCount();
        scCh.SetNewCount();
        pos.SetNewPosition(new Vector3(50, 4, 48));
        flag.setTrue();
    }

    public void startGame()
    {
        SceneManager.LoadScene("Intermediate");
    }
}
