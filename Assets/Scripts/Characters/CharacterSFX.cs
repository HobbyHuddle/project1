using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "New Character SFX", menuName = "Game/Character SFX")]
    public class CharacterSFX : ScriptableObject
    {
        public AudioClip runSfx;
        public AudioClip deathSfx;
        public AudioClip jumpSfx;
    }
}