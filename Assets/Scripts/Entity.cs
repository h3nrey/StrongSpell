using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Entity/basic Entity")]
public class Entity : ScriptableObject {
    public string entityName;
    public Sprite sprite;
    public int life;
}
