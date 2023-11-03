using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowItem : MonoBehaviour
{
    [SerializeField] private Transform target; // 追従する対象
    [SerializeField] private Vector3 offset; // オフセット（World Spaceのオフセット）
    private RectTransform rectTransform;

    public void SetTarget(Transform target, Vector3 offset)
    {
        this.target = target;
        this.offset = offset;
        rectTransform = GetComponent<RectTransform>();
        RefreshPosition();
    }
    public void SetTarget(Transform target)
    {
        SetTarget(target, Vector3.zero);
    }

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshPosition();
    }

    private void RefreshPosition()
    {
        if (target)
        {
            // World PositionをScreen Positionに変換
            Vector2 screenPos = Camera.main.WorldToScreenPoint(target.position + offset);
            rectTransform.position = screenPos;
        }
    }
}
