using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerObjectsScript : MonoBehaviour
{
    //public List<GameObject> _objects1D = new List<GameObject>();
    //public List<GameObject> _objects2D = new List<GameObject>();
    //public List<GameObject> _objects3D = new List<GameObject>();

    //void Awake()
    //{
    //    GameObject[] _objects1D = GameObject.FindGameObjectsWithTag("Obj1D");
    //    this._objects1D.AddRange(_objects1D);

    //    GameObject[] _objects2D = GameObject.FindGameObjectsWithTag("Obj2D");
    //    this._objects2D.AddRange(_objects2D);

    //    GameObject[] _objects3D = GameObject.FindGameObjectsWithTag("Obj3D");
    //    this._objects3D.AddRange(_objects3D);
    //}

    //void Update()
    //{
    //    CheckForNewObjects1D();
    //    CheckForNewObjects2D();
    //    CheckForNewObjects3D();
    //}

    //void CheckForNewObjects1D()
    //{
    //    GameObject[] _objects1D = GameObject.FindGameObjectsWithTag("Obj1D");

    //    foreach (GameObject obj1d in _objects1D)
    //    {
    //        if (!this._objects1D.Contains(obj1d))
    //        {
    //            this._objects1D.Add(obj1d);
    //        }
    //    }
    //}

    //void CheckForNewObjects2D()
    //{
    //    GameObject[] _objects2D = GameObject.FindGameObjectsWithTag("Obj2D");

    //    foreach (GameObject obj2d in _objects2D)
    //    {
    //        if (!this._objects2D.Contains(obj2d))
    //        {
    //            this._objects2D.Add(obj2d);
    //        }
    //    }
    //}

    //void CheckForNewObjects3D()
    //{
    //    GameObject[] _objects3D = GameObject.FindGameObjectsWithTag("Obj3D");

    //    foreach (GameObject obj3d in _objects3D)
    //    {
    //        if (!this._objects3D.Contains(obj3d))
    //        {
    //            this._objects3D.Add(obj3d);
    //        }
    //    }
    //}

    // --------------------------------------------------------------------------------------------------------

    public List<GameObject> _objects1D = new List<GameObject>();
    public List<GameObject> _objects2D = new List<GameObject>();
    public List<GameObject> _objects3D = new List<GameObject>();

    [HideInInspector]
    public List<GameObject> taggedObjects = new List<GameObject>();

    //GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("tagToTrack");

    private void Awake()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.tag == "Obj1D")
            {
                _objects1D.Add(obj);
            }
            else if (obj.tag == "Obj2D")
            {
                _objects2D.Add(obj);
            }
            else if (obj.tag == "Obj3D")
            {
                _objects3D.Add(obj);
            }
        }



        //foreach (GameObject obj in objectsWithTag)
        //{
        //    taggedObjects.Add(obj);
        //}
    }

    private void Start()
    {
        foreach (GameObject obj1d in _objects1D) //Deactivate 1D
        {
            obj1d.SetActive(false);
        }
    }

    private void Update()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.tag == "Obj1D" && !_objects1D.Contains(obj))
            {
                _objects1D.Add(obj);
            }
            else if (obj.tag == "Obj2D" && !_objects2D.Contains(obj))
            {
                _objects2D.Add(obj);
            }
            else if (obj.tag == "Obj3D" && !_objects3D.Contains(obj))
            {
                _objects3D.Add(obj);
            }


            if ((_objects2D.Contains(obj)) || (obj.tag == "Obj1D" && _objects3D.Contains(obj)))
            {
                _objects1D.Remove(obj);
            }
            else if ((_objects1D.Contains(obj)) || (obj.tag == "Obj2D" && _objects3D.Contains(obj)))
            {
                _objects2D.Remove(obj);
            }
            else if ((_objects1D.Contains(obj)) || (obj.tag == "Obj3D" && _objects2D.Contains(obj)))
            {
                _objects3D.Remove(obj);
            }
        }
    }
}
