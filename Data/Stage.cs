using UnityEngine;

namespace Jun.Data
{
    [CreateAssetMenu(fileName = "Stage", menuName = "PCR/Make New Stage")]
    public class Stage : ScriptableObject
    {
        public Sprite panelBg;

        public Sprite[] bg = new Sprite[3];

        public string mapName;

        public Monster[] monsters = new Monster[6];

        public Item[] Items = new Item[6];
        
        public Item[] rewards = new Item[6];

        public Wave[] waves = new Wave[3];
    }
}