using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BagsManager: MonoBehaviour
{
     public List<Transform> spawnPositions;
     public GameObject bagPrefab;

    
     private void Awake()
     {
          foreach (var spawnPosition in spawnPositions)
          {
              AbstractFactory.Instance.CreateGameObject(bagPrefab, spawnPosition, transform);
          }
     }
}