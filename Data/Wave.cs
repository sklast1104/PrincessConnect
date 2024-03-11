using UnityEngine;

namespace Jun.Data
{
    [CreateAssetMenu(fileName = "Wave", menuName = "PCR/Make New Wave")]
    public class Wave : ScriptableObject
    {
        public Monster[] monsters = new Monster[3];
        public Vector3[] wavePos = new Vector3[3];
    }
}