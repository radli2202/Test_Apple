using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class PoolItem
{

    public GameObject objectToPool;
    public int countPool;
    public bool shouldExpand = true;

    public PoolItem(GameObject obj, int amt, bool exp = true)
    {
        objectToPool = obj;
        countPool = Mathf.Max(amt, 2);
        shouldExpand = exp;
    }
}
public class PoolObjMy : MonoBehaviour
{
	public static PoolObjMy Pref;
    public List<PoolItem> PrefPoolList;


	public List<List<GameObject>> pooledObjectsList;
	public List<GameObject> pooledObjects;
	private List<int> positions;

	void Awake()
	{

		Pref = this;

		pooledObjectsList = new List<List<GameObject>>();
		pooledObjects = new List<GameObject>();
		positions = new List<int>();


		for (int i = 0; i < PrefPoolList.Count; i++)
		{
			ObjectPoolItemToPooledObject(i);
		}

	}
	int index;

	public GameObject GetPooledObject()
	{

		int curSize = pooledObjectsList[index].Count;
		for (int i = positions[index] + 1; i < positions[index] + pooledObjectsList[index].Count; i++)
		{

			if (!pooledObjectsList[index][i % curSize].activeInHierarchy)
			{
				positions[index] = i % curSize;				
				return pooledObjectsList[index][i % curSize];
			}
		}

		if (PrefPoolList[index].shouldExpand)
		{

			GameObject obj = (GameObject)Instantiate(PrefPoolList[index].objectToPool);
			obj.SetActive(false);
			//obj.transform.parent = this.transform;
			pooledObjectsList[index].Add(obj);
			return obj;

		}
		return null;
	}
	public GameObject GetPooledObject(GameObject Pref,Vector3 position, Quaternion q,Transform Parent) 
	{
		Pref = GetPooledObject();
		Pref.transform.position = position;
		Pref.transform.rotation = q;
		if (Parent == null) { Pref.transform.parent = null; } else Pref.transform.parent = Parent;

		return Pref;
	
	}

	public List<GameObject> GetAllPooledObjects(int index)
	{
		return pooledObjectsList[index];
	}


	public int AddObject(GameObject GO, int amt = 3, bool exp = true)
	{
		PoolItem item = new PoolItem(GO, amt, exp);
		int currLen = PrefPoolList.Count;
		PrefPoolList.Add(item);
		ObjectPoolItemToPooledObject(currLen);
		return currLen;
	}


	void ObjectPoolItemToPooledObject(int index)
	{
		PoolItem item = PrefPoolList[index];

		pooledObjects = new List<GameObject>();
		for (int i = 0; i < item.countPool; i++)
		{
			GameObject obj = (GameObject)Instantiate(item.objectToPool);
			obj.SetActive(false);
			obj.transform.parent = this.transform;
			pooledObjects.Add(obj);
		}
		pooledObjectsList.Add(pooledObjects);
		positions.Add(0);

	}
}
