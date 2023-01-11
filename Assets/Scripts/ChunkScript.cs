using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkScript : MonoBehaviour
{
    public Transform player;
    public Chunk[] chunkPrefabs;
    public Chunk firstChunk;
    public List<Chunk> spawnedChunks = new List<Chunk>();

    private void Start()
    {
        spawnedChunks.Add(firstChunk);
    }
    //Определение положения спавна чанков
    private void Update()
    {
        if (spawnedChunks.Count < 20)
        {
            if (player.position.z > spawnedChunks[spawnedChunks.Count - 1].end.position.z - 25)
            {
                SpawnedChunks();
            }
        }
    }
    //Создание чанков пола, добавление их в список 
    private void SpawnedChunks()
    {
        Chunk newCunk = Instantiate(chunkPrefabs[Random.Range(0, chunkPrefabs.Length)]);
        newCunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].end.position - newCunk.start.localPosition;
        spawnedChunks.Add(newCunk);
    }
}
