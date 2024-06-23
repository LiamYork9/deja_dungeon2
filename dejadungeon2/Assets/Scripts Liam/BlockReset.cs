using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockReset : MonoBehaviour
{
    Vector2 startPos;
    public static List<BoxCollider2D> blocks = new List<BoxCollider2D>();
    static bool subscribed = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        if (!subscribed) {
            SceneManager.activeSceneChanged += ClearBlocks;
            subscribed = true;
        }
        BoxCollider2D original = GetComponent<BoxCollider2D>();
        BoxCollider2D box = new GameObject().AddComponent<BoxCollider2D>();
        box.size = original.size;
        box.offset = original.offset;
        box.transform.parent = null;
        box.transform.position = startPos;
        box.isTrigger = true;
        box.gameObject.layer = 10;
        blocks.Add(box);
        EventManager.ResetEvent += BlockReturn;
    }

    static void ClearBlocks(UnityEngine.SceneManagement.Scene arg1, UnityEngine.SceneManagement.Scene arg2) { blocks.Clear(); }

    // Update is called once per frame
    private void BlockReturn()
    {
        transform.position = startPos;
        gameObject.GetComponent<ShovableObject>().moving = false;
    }
}
