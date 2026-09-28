using UnityEngine;
[CreateAssetMenu(fileName = "PlayerCharacters", menuName = "Scriptable Objects/PlayerCharacters")]
public class CharacterInfo : ScriptableObject
{
    public string thisCharacterName;
    public int thisCharacterMoveSpeed;
    public int thisCharacterJumpSpeed;

    private enum AttackType
    {
        Unknown,
        Melee,
        Ranged,
    }

    [SerializeField] private AttackType AttackForm = AttackType.Unknown;
}
