using UnityEngine;
[CreateAssetMenu(fileName = "PlayerCharacters", menuName = "Scriptable Objects/PlayerCharacters")]
public class CharacterInfo : ScriptableObject
{
    public string thisCharacterName;
    public int thisCharacterMoveSpeed;
    public int thisCharacterJumpSpeed;
}
