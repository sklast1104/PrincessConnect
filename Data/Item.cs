using UnityEngine;

namespace Jun.Data
{
    [CreateAssetMenu(fileName = "Item", menuName = "PCR/Make New Item")]
    public class Item : ScriptableObject
    {
        public Sprite icon;

        public string itemName;

        public int count;
    }
}