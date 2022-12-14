using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Horizontal;
    [SerializeField] public float VerticalSpeed;
    [SerializeField] public float SpeedMultiplier;
    public List<Transform> Coffees;
    [SerializeField] float OffsetZ = 2;
    [SerializeField] float LerpSpeed = 1;
    Sequence seq;
    void Start()
    {
        // Coffees.Add(transform.GetChild(0));
        CollectedCoffeeData.instance.CoffeeList.Add(transform.GetChild(0));
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(Horizontal, 0, VerticalSpeed) * SpeedMultiplier * Time.deltaTime;
        if (CollectedCoffeeData.instance.CoffeeList.Count > 1) {
            CoffeeFollow();
        }



        //float clampLimit = Mathf.Clamp(transform.position.x,-10.5f,11f);
        //transform.position = new Vector3(clampLimit,transform.position.y,transform.position.z);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Empty")) {
            CollectedCoffeeData.instance.CoffeeList.Add(other.transform);
            other.tag = "CollectedEmptyCup";
            other.gameObject.AddComponent<CollectedCoffee>();
            other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
            // var seq = DOTween.Sequence();
            seq = DOTween.Sequence();
            seq.Kill();
            seq = DOTween.Sequence();
            for (int i = CollectedCoffeeData.instance.CoffeeList.Count - 1; i > 0; i--)
            {
                seq.WaitForCompletion(true);
                seq.Join(CollectedCoffeeData.instance.CoffeeList[i].DOScale(2.4f, 0.2f));
                seq.AppendInterval(0.05f);
                seq.Join(CollectedCoffeeData.instance.CoffeeList[i].DOScale(2.29f, 0.2f));
            }
        }
    }

    void CoffeeFollow() {
        for (int i = 1; i <  CollectedCoffeeData.instance.CoffeeList.Count; i++)
        {
            Vector3 PrePos =  CollectedCoffeeData.instance.CoffeeList[i - 1].transform.position + Vector3.forward * OffsetZ;
            Vector3 CurPos =  CollectedCoffeeData.instance.CoffeeList[i].position;
            // PrePos = new Vector3(PrePos.x/2, PrePos.y, PrePos.z);
             CollectedCoffeeData.instance.CoffeeList[i].transform.position = Vector3.Lerp(CurPos, PrePos, LerpSpeed * Time.deltaTime);
        }
    }
}
