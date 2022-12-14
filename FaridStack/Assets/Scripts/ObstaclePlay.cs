using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstaclePlay : MonoBehaviour
{
    [SerializeField] Transform ParticleTransform;
    [SerializeField] GameObject Smoke;
    [SerializeField] ParticleSystem SmokePlay;

    //private void Start()
    //{
    //    transform.DORotate(Vector3.up*90,0.1f).SetLoops(-1,LoopType.Incremental);
    //}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("CollectedEmptyCup"))
        {
            ParticleTransform.position = other.transform.position;
            SmokePlay.Play();
        }
      
    }
}
