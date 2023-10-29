using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursolManager : MonoBehaviour
{
    Vector3 mousePos, worldPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PanelManager.gameStatus != "Play")
        {
            return;
        }
        //マウス座標の取得
        mousePos = Input.mousePosition;
        //スクリーン座標をワールド座標に変換
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, 4f, 10f));
        // X 座標を制限
        worldPos.x = Mathf.Clamp(worldPos.x, -2.5f, 2.5f)+0.5f;
        worldPos.y = Mathf.Clamp(worldPos.y, 4.2f, 4.2f); // ワールド座標のy軸がなぜか-5になるため
        //ワールド座標を自身の座標に設定
        transform.position = worldPos;
    }
}
