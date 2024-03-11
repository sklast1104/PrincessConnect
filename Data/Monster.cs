using UnityEngine;

namespace Jun.Data
{
    [CreateAssetMenu(fileName = "Monster", menuName = "PCR/Make New Monster")]
    public class Monster : ScriptableObject
    {
        public Sprite icon;

        public string monName;

        public int attack;

        public int hp;

        public string prefabPath;
    }
}


