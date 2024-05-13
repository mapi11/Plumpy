using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> taggedObjects1 = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> taggedObjects2 = new List<GameObject>();

    [Space]
    [Header("Fade objects")]
    //public Renderer[] renderers1D;
    //public Renderer[] renderers3D;

    public List<Renderer> fade1DObjects1D = new List<Renderer>();
    public List<Renderer> fade1DObjects3D = new List<Renderer>();

    [HideInInspector]
    public GameObject[] objectsWithTag1D;
    [HideInInspector]
    public GameObject[] objectsWithTag3D;


    private void Awake()
    {
        //MoveObjectsFromListToArray();

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

        // ----------------------------------------------------------------------------------Fade

        objectsWithTag1D = GameObject.FindGameObjectsWithTag("Fade1D");
        objectsWithTag3D = GameObject.FindGameObjectsWithTag("Fade3D");

        foreach (GameObject obj in objectsWithTag1D)
        {
            Renderer renderer1D = obj.GetComponent<Renderer>();
            if (renderer1D != null)
            {
                fade1DObjects1D.Add(renderer1D);
            }
        }

        foreach (GameObject obj in objectsWithTag3D)
        {
            Renderer renderer3D = obj.GetComponent<Renderer>();
            if (renderer3D != null)
            {
                fade1DObjects3D.Add(renderer3D);
            }
        }
        Debug.Log("elements 1d: " + fade1DObjects1D.Count + " Elements 3d: " + fade1DObjects3D.Count);
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
        //// �������� �� �������� �������� �� �����
        //taggedObjects1.RemoveAll(item => item == null);
        //taggedObjects2.RemoveAll(item => item == null);

        // �������� �� ��������� ����� ���������
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

    public void FadeObjects1D(float _transparencyAmount1D)
    {
        foreach (Renderer renderer in fade1DObjects1D)
        {
            Material material = renderer.material; // �������� �������� �������

            material.SetFloat("_Mode", 2); // ������������� ���������� �����
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha); // ������������� ����� �����
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha); // ������������� ������� ����� �����
            material.SetInt("_ZWrite", 0); // �������� ������ � ����� �������

            Color color = material.color; // �������� ���� ���������
            color.a = _transparencyAmount1D; // ������������� ������� ������������
            material.color = color; // ��������� ���������
        }
    }

    public void FadeObjects3D(float _transparencyAmount3D)
    {
        foreach (Renderer renderer in fade1DObjects3D)
        {
            Material material = renderer.material; // �������� �������� �������

            material.SetFloat("_Mode", 2); // ������������� ���������� �����
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha); // ������������� ����� �����
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha); // ������������� ������� ����� �����
            material.SetInt("_ZWrite", 0); // �������� ������ � ����� �������

            Color color = material.color; // �������� ���� ���������
            color.a = _transparencyAmount3D; // ������������� ������� ������������
            material.color = color; // ��������� ���������
        }
    }

    //public void MoveObjectsFromListToArray()
    //{
    //    // ���������, ���������� �� ����� � ������� ��� �������� ���� ��������
    //    if (fade1DObjects1D.Count > renderers1D.Length)
    //    {
    //        Debug.LogError("Not enough space in the array to move all objects");
    //        return;
    //    }

    //    // �������� ������� �� ������ � ������
    //    for (int i = 0; i < fade1DObjects1D.Count; i++)
    //    {
    //        renderers1D[i] = fade1DObjects1D[i];
    //    }

    //    // ������� ������ ����� �������� ��������
    //    fade1DObjects1D.Clear();
    //}
}