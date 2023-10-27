using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private ItemType itemType = ItemType.c;
    [SerializeField] private int itemScore;
    [SerializeField] private GameObject nextItemPrefab;


    public int myNumber;
    private static int totalNumber = 0;
    
    void Start()
    {
        totalNumber++;
        myNumber = totalNumber;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent(out Items otherItem)) 
        {
            if(otherItem.itemType != itemType)
            {
                return;
            }
            if(myNumber >= otherItem.myNumber)
            {
                if (nextItemPrefab != null)
                {
                    GameObject scoreObj = GameObject.Find("ScoreManager");
                    scoreObj.GetComponent<ScoreManager>().ScoreChanger(itemScore);

                    Debug.Log(nextItemPrefab);

                    // 速度の平均
                    Vector3 velocity = (GetComponent<Rigidbody2D>().velocity + otherItem.gameObject.GetComponent<Rigidbody2D>().velocity) / 2;
                    // 回転の平均
                    Quaternion rotation = Quaternion.Lerp(transform.rotation, otherItem.transform.rotation, 0.5f);
                    // 位置の平均
                    Vector3 centerPosition = (transform.position + otherItem.transform.position) / 2;

                    GameObject newItem = Instantiate(nextItemPrefab, centerPosition,rotation);
                    newItem.GetComponent<Rigidbody2D>().velocity = velocity;

                }
            }
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }
}
