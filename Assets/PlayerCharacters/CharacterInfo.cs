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

    public enum AbilityOneType
    {
        Unknown,
    }

    public enum AbilityTwoType
    {
        Unknown,
        Glide,
    }

    public AttackType AttackForm = AttackType.Unknown;
    public AbilityOneType AbilityOne = AbilityOneType.Unknown;
    public AbilityTwoType AbilityTwo = AbilityTwoType.Unknown;
}
