using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects / Enemy")]
public class EnemyScriptable : ScriptableObject
{
    public float health;
    public float moveSpeed;
    public float damage;
    public float sightRadius;
}
