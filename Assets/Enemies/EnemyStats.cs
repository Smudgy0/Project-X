using UnityEngine;
using UnityEngine.UIElements;
[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public int health;

    public Color MyColor;
    public bool RandomStats;

    public int Speed;
}
