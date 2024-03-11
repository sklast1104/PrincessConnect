using UnityEngine;

namespace Jun.Data
{
    [CreateAssetMenu(fileName = "Character", menuName = "PCR/Make New Character")]
    public class Character : ScriptableObject
    {
        public Sprite icon;

        public string charName;

        public int attack;

        public int hp;
    }
}