using UnityEngine;

namespace Jun.Scene.Battle
{
    public class CharStartPos : MonoBehaviour
    {
        [SerializeField]
        public Vector3[] startPoses = new Vector3[5];

        public Vector3[] clearPoses = new Vector3[5];
        
        public float[] offSets = new float[5];

    }
}