using DG.Tweening;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public class FinalScript : MonoBehaviour
{
    [SerializeField] private List<Transform> FinalTransforms;
    //[SerializeField] private GameObject Player;
    //[SerializeField] private float _finalMoneyAmount;
    //[SerializeField] private GameObject _finalMoney;

    //private int _placeCount = 0;

    Sequence seq;
    private void OnTriggerEnter(Collider other)
    {
        seq = DOTween.Sequence();
        seq.Kill();
        seq = DOTween.Sequence();

        if (other.gameObject.CompareTag("Empty")
            ||other.gameObject.CompareTag("CollectedEmptyCup")
            || other.gameObject.CompareTag("Juice") 
            || other.gameObject.CompareTag("Bubble")
            || other.gameObject.CompareTag("Ice") 
            || other.gameObject.CompareTag("UpdatedCup"))
        {

            PlayerController Hand = FindObjectOfType<PlayerController>();
            Hand.SpeedMultiplier = 0;
            Hand.VerticalSpeed = 0;
            StartCoroutine(StartAnimation());
        }
    }

     IEnumerator StartAnimation()
    {
        for (int i = CollectedCoffeeData.instance.CoffeeList.Count - 1; i > 0; i--)
        {
            CollectedCoffeeData.instance.CoffeeList[i].SetParent(FinalTransforms[i]);
            seq.WaitForCompletion(true);
            seq.AppendInterval(0.02f);
            CollectedCoffeeData.instance.CoffeeList[i].DOLocalJump(Vector3.zero, 1, 1, 0.5f);
            //CollectedCoffeeData.instance.CoffeeList[i].localPosition = Vector3.zero;
            CollectedCoffeeData.instance.CoffeeList.Remove(CollectedCoffeeData.instance.CoffeeList[i]);

            yield return new WaitForSeconds(0.5f);
        }

    }

    
}