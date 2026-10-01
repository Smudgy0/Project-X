using UnityEngine;
[CreateAssetMenu(fileName = "PlayerCharacters", menuName = "Scriptable Objects/PlayerCharacters")]
public class CharacterInfo : ScriptableObject
{
    public string thisCharacterName;
    public int thisCharacterMoveSpeed;
    public int thisCharacterJumpSpeed;

    public enum AttackType
    {
        Unknown,
        Melee,
        Ranged,
    }

    public AttackType AttackForm = AttackType.Unknown;
}
