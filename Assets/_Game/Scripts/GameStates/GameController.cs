using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [field: SerializeField]
    public Unit PlayerUnitPrefab {  get; private set; }
    [field: SerializeField]
    public Transform PlayerUnitSpawnLocation { get; private set;}
    [field: SerializeField]
    public UnitSpawner UnitSpawner { get; private set; }
}
