using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObstacleController : MonoBehaviour
{
    private void Start()
    {
        transform.DORotate(Vector3.up * 90, 0.1f).SetLoops(-1, LoopType.Incremental);
        
        
    }

}
