using UnityEngine;

public class Sorting : MonoBehaviour
{
    SpriteRenderer thisSR; //Sprite Renderer of Current Object
    GameObject parent; //Parent of Current Object

    void Start()
    {
        thisSR = GetComponent<SpriteRenderer>();
        parent = transform.parent.gameObject;
    }

    /// <summary>
    /// FIX default Unity sorting
    /// </summary>
    void Update()
    {
        if (parent.transform.position.y < GM.Instance.player.transform.position.y - GM.Instance.transparencyOffset)
            thisSR.sortingOrder = GM.Instance.defaultSortingLayer + 1;
        else
            thisSR.sortingOrder = GM.Instance.defaultSortingLayer - 1; 
    }
}
