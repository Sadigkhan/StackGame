using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectedCoffee : MonoBehaviour
{
    Sequence seq;
    //[SerializeField] private GameObject ParentDropArea;
    [SerializeField] private List<Transform> FinalTransforms;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Empty")) //stekanin basqa stekana deyib onu goturmesi
        {
            other.tag = "CollectedEmptyCup";
            CollectedCoffeeData.instance.CoffeeList.Add(other.transform);
            other.gameObject.AddComponent<CollectedCoffee>();
            other.gameObject.AddComponent<Rigidbody>().isKinematic = true; 

            // var seq = DOTween.Sequence();
            seq = DOTween.Sequence();
            seq.Kill();
            seq = DOTween.Sequence();
            for (int i = CollectedCoffeeData.instance.CoffeeList.Count - 1; i > 0; i--)
            {
                seq.WaitForCompletion(true);
                seq.Join(CollectedCoffeeData.instance.CoffeeList[i].DOScale(2.40f, 0.1f));
                seq.AppendInterval(0.02f);
                seq.Join(CollectedCoffeeData.instance.CoffeeList[i].DOScale(2.29f, 0.1f));
            }
        }

        if (other.CompareTag("JuiceMachine"))
        {

            if (transform.CompareTag("CollectedEmptyCup"))
            {
                transform.GetChild(1).gameObject.SetActive(true);
                gameObject.tag = "Juice"; //Juice TRUE

            }


           

        }
        if (other.CompareTag("BubbleMachine"))
        {
            if (transform.CompareTag("Juice"))
            {
                transform.GetChild(2).gameObject.SetActive(true); //Bubble TRUE
                gameObject.tag = "Bubble";
            }
        }

        if (other.CompareTag("IceMachine"))
        {
            if (transform.CompareTag("Juice") || transform.CompareTag("Bubble"))
            {
                transform.GetChild(3).gameObject.SetActive(true); //Ice TRUE
                gameObject.tag = "Ice";
            }
        }

        if (other.CompareTag("Drop"))
        {
            if(transform.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.isKinematic = false;
                CollectedCoffeeData.instance.CoffeeList.Remove(gameObject.transform);
                rb.velocity = Vector3.down * 30;
            }
            
        }
        if (other.CompareTag("Sell"))
        {
            //float saleOffset = 1f;
            gameObject.transform.SetParent(other.gameObject.transform);
            gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            gameObject.transform.localPosition = new Vector3(1.8f, -0.37f, -0.124f);
            gameObject.transform.DOLocalMove( new Vector3( 0.323f, -0.37f,-0.124f), 0.4f);

            CollectedCoffeeData.instance.CoffeeList.Remove(gameObject.transform);
            

        }


        if (other.CompareTag("UpdateJuice"))
        {
            if (transform.CompareTag("Juice") || transform.CompareTag("Bubble") || transform.CompareTag("Ice"))
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(false);
                transform.GetChild(4).gameObject.SetActive(true); //UpdatedCup TRUE
               
                gameObject.tag = "UpdatedCup";
            }
        }

       


        if (other.CompareTag("Obstacle") && this.gameObject.layer != 6)
        {
            CollectedCoffeeData.instance.CoffeeList.Remove(transform);
            Destroy(gameObject);
        }
    }
}
