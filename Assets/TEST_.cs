using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> taggedObjects1 = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> taggedObjects2 = new List<GameObject>();

    private void Awake()
    {
        GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag("Obj1D");

        foreach (GameObject obj in objectsWithTag1)
        {
            taggedObjects1.Add(obj);

        }
        GameObject[] objectsWithTag2 = GameObject.FindGameObjectsWithTag("Obj2D");

        foreach (GameObject obj in objectsWithTag2)
        {
            taggedObjects2.Add(obj);
        }
    }

    void Start()
    {
        foreach (GameObject obj2d in taggedObjects1) // Off 1D
        {
            obj2d.SetActive(false);
        }
    }

    void Update()
    {
        //// Проверка на удаление элемента со сцены
        //taggedObjects1.RemoveAll(item => item == null);
        //taggedObjects2.RemoveAll(item => item == null);

        // Проверка на появление новых элементов
        GameObject[] objectsWithTag1D = GameObject.FindGameObjectsWithTag("Obj1D");
        GameObject[] objectsWithTag2D = GameObject.FindGameObjectsWithTag("Obj2D");

        foreach (GameObject obj in objectsWithTag1D)
        {
            if (!taggedObjects1.Contains(obj))
            {
                taggedObjects1.Add(obj);
                Debug.Log("Added" + taggedObjects1.Count);
            }
            else
            {
                taggedObjects1.RemoveAll(item => item == null);
            }
        }

        foreach (GameObject obj in objectsWithTag2D)
        {
            if (!taggedObjects2.Contains(obj))
            {
                taggedObjects2.Add(obj);
                Debug.Log("Added" + taggedObjects2.Count);
            }
            else
            {
                taggedObjects2.RemoveAll(item => item == null);
            }
        }
    }
}