using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private ItemType itemType = ItemType.c;
    [SerializeField] private int itemScore;
    [SerializeField] private GameObject nextItemPrefab;

    public AudioClip hitSound;

    public int myNumber;
    private static int totalNumber = 0;

    private bool firstFlag = true;
    //private bool isGround = false;

    void Start()
    {
        totalNumber++;
        myNumber = totalNumber;
    }

    private void Update()
    {
        if(PanelManager.gameStatus == "Over")
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        if (gameObject.transform.position.y >= 3.6)
        {
            GameObject.Find("PanelManager").GetComponent<PanelManager>().GameOver();
        }

        if(gameObject.transform.position.y < -6.0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (firstFlag)
        {
            GameObject.Find("ItemManager").GetComponent<ItemsManager>().setGroundFlag(true);
            firstFlag = false;
        }
        if(other.gameObject.TryGetComponent(out Items otherItem)) 
        {
            if(otherItem.itemType != itemType)
            {
                return;
            }
            if(myNumber >= otherItem.myNumber)
            {
                GameObject scoreObj = GameObject.Find("ScoreManager");
                scoreObj.GetComponent<ScoreManager>().ScoreChanger(itemScore);

               
                AudioSource.PlayClipAtPoint(hitSound, gameObject.transform.position);
                Debug.Log("hit");

                if (nextItemPrefab != null)
                {
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
            Destroy(gameObject);
        }
    }
}
