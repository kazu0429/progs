using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    c,
    cplus,
    csharp,
    python,
    java,
    js,
    ruby,
    dart,
    rust,
    swift
};

public class ItemsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ItemPrefabs;

    [SerializeField] private Image nextItemImage;
    [SerializeField] private Image nowItemImage;

    public int nextItemIndex;
    public int nowItemIndex;


    private int ChoiceNextItem()
    {
        int index = Random.Range(0, ItemPrefabs.Length);
        nextItemImage.sprite = ItemPrefabs[index].GetComponent<SpriteRenderer>().sprite;
        return index;
    }

    private void ChangeItemSprite(int index)
    {
        nowItemImage.sprite = ItemPrefabs[index].GetComponent<SpriteRenderer>().sprite;
    }

    private void Start()
    {
        nowItemIndex = Random.Range(0, ItemPrefabs.Length);
        ChangeItemSprite(nowItemIndex);
        nextItemIndex = ChoiceNextItem();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 cursorPos = GameObject.Find("cursor").transform.position;

            GameObject createdItem = Instantiate(ItemPrefabs[nowItemIndex], cursorPos, Quaternion.identity);
            createdItem.transform.Rotate(new Vector3(0, 0, Random.Range(-30, 30)));
            createdItem.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-30, 30);

            // 前のアイテムをセット
            ChangeItemSprite(nextItemIndex);
            nowItemIndex = nextItemIndex;
            // 次のアイテムをセット
            nextItemIndex = ChoiceNextItem();
        }
    }
}
