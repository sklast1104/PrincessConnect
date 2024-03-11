using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessChecker : MonoBehaviour
{
    [SerializeField] private GameObject princess;
    
    public GameObject FindFirstPrincess()
    {
        return princess;
    }
}
