using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleParentMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveX(11f, 3f).SetLoops(-1, LoopType.Yoyo);
    }

    
}
