using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public GameObject pointPrefab;
    private bool pointIsSpawned = false;
    public bool isTriggered = false;
    private float timer;

    private void Update()
    {
        if (isTriggered == true)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 5)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PointSpawn();
    }
    //Создание поинтов над чанком (с 50% шансом) 
    private void PointSpawn()
    {
        if (Random.Range(0,10) < 5)
        {
            if (pointIsSpawned == false)
            {
                Instantiate(pointPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3, gameObject.transform.position.z), Quaternion.identity);
                pointIsSpawned = true;
            }
        }  
    }
    //Если происходит коллизия чанка с обьектом, имеющим слой Player - срабатывает тригер чанка
    //этот триггер необходим для: 1. запуска таймера отсчета в Update. По истечении 5 секунд, чанк
    //самоликвидируется из проэкта. 2. удаления элементов из списка, в котором чанки хранятся после создания (в скрипте )
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isTriggered = true;
        }
    }
}
