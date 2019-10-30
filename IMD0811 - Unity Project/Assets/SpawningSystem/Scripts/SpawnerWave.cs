using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Wave", menuName = "Spawner Wave")]
public class SpawnerWave : ScriptableObject
{
    [FormerlySerializedAs("enemiesToSpawn")] 
    [SerializeField] GameObject[] elementsToSpawn;
    [SerializeField] int[] amountToSpawn;
    [SerializeField] float[] timeBetweenSpawn;
    
    public int NumOfElements() { return elementsToSpawn.Length; }
    public GameObject GetElement(int pos) { return elementsToSpawn[pos]; }
    public float GetSpawnInterval(int pos) { return timeBetweenSpawn[pos]; }
    public int GetSpawnAmount(int pos) { return amountToSpawn[pos]; }
}