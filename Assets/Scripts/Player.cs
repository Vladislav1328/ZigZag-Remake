using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int points = 0;
    public float speed = 4f;
    public StarterScript starter;
    private bool _leftTrigger = false;
    private bool _rightTrigger = true;
    public Text pointsCounter;
    public Text finalCount;
    public GameObject pauseButton;
    public GameObject gameOverPan;
    public ChunkScript chunkGenerator;
    private Vector3 directionL;
    private Vector3 directionR;
    public Vector3 startPos;
    private Touch theTouch;

    void Update()
    {
        GameOver();
        ClickRegistration();
        PlayerAutoMoove();

        //����� �������� ������� � UI TXT
        pointsCounter.text = "Points: " + points;
    }
    //��� �������� � ����� �������� � �������-����������� (������� ����� ���� ������������� �����-�������),
    //���� ������ �������������. 
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other);
        points += 1;
    }
    //������ ���������� ������� �������� ������
    private void LeftDirection()
    {
        directionL.z = -1;
        directionL.x = -1;
    }
    private void RightDirection()
    {
        directionR.z = 1;
        directionR.x = -1;
    }
    //��� �������, ������������ ������ ����� ����, ����� ��������� �� 0
    private void GameOver()
    {
        if (gameObject.transform.position.y < -9)
        {
            gameOverPan.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            finalCount.text = "Result: " + points + " points";
            starter.gameIsStarted = false;
            Time.timeScale = 0f;
        }
    }
    //���� ���� ��� ����������� - ����������� ������� ������������ �����������
    private void ClickRegistration()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Ended)
            {
                if (_leftTrigger)
                {
                    _leftTrigger = false;
                    _rightTrigger = true;

                }
                else
                {
                    _rightTrigger = false;
                    _leftTrigger = true;
                }
            }
        }

        if (_leftTrigger == true)
        {
            LeftDirection();
        }
        else if (_rightTrigger == true)
        {
            RightDirection();
        }
    }
    //���������� �������� �������� � ���� �� ���� ��������� ������
    private void PlayerAutoMoove()
    {
        if (_leftTrigger)
        {
            transform.Translate((directionL * speed * Time.deltaTime) * 3);
        }
        if (_rightTrigger)
        {
            transform.Translate((directionR * speed * Time.deltaTime) * 3);
        }
    }
    //��� �������� ������ � ����� ������, � ������ ������ ��������� ������� �������, ���������� ����� ��� ������ ����� ������
    private void OnCollisionEnter(Collision collision)
    {
        if (chunkGenerator.spawnedChunks.Count > 8)
        {
            chunkGenerator.spawnedChunks.RemoveAt(0);
        }
    }
}
