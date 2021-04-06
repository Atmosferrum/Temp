using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GOPoolItem
{
    public GameObject[] goToPool; //Object to Pool
    public int goQwty; //Qwantity of Object to Pool
    public GameObject father; //Parent to contain Pooled Object
    public bool addMore = true; //If there's need to Create more objects than it's already Pooled
}

public class Pooler : MonoBehaviour
{
    public static Pooler Instance; //Pooler Instance

    public List<GOPoolItem> itemsToPool;
    public List<GameObject> pooledGO;

    /// <summary>
    /// Pooling all Set Objects
    /// </summary>
    private void Awake()
    {
        Instance = this;

        pooledGO = new List<GameObject>();

        foreach (GOPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.goQwty; i++)
            {
                GameObject go = Instantiate(item.goToPool[Random.Range(0, item.goToPool.Length)]);
                go.transform.parent = item.father.transform;
                go.SetActive(false);
                pooledGO.Add(go);
            }
        }
    }

    /// <summary>
    /// GET Pooled Object
    /// </summary>
    /// <param name="tag">Tag of Object that to GET from Pool</param>
    /// <returns></returns>
    public GameObject GetPooledGO(string tag)
    {
        for (int i = 0; i < pooledGO.Count; i++)
        {
            if (!pooledGO[i].activeInHierarchy && pooledGO[i].tag == tag)
            {
                return pooledGO[i];
            }
        }
        foreach (GOPoolItem item in itemsToPool)
        {
            if (item.goToPool[Random.Range(0, item.goToPool.Length)].tag == tag)
            {
                if (item.addMore)
                {
                    GameObject go = Instantiate(item.goToPool[Random.Range(0, item.goToPool.Length)]);
                    go.transform.parent = item.father.transform;
                    go.SetActive(false);
                    pooledGO.Add(go);
                }
            }
        }
        return null;
    }
}
