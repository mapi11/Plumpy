using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyController : MonoBehaviour
{
    public float transparencyAmount = 0.5f; // ������ ������� ������������

    public Renderer[] renderers;

    //public Renderer[] _renderers;

    void Start()
    {
        //_renderers = renderers;

        foreach (Renderer renderer in renderers)
        {
            Material material = renderer.material; // �������� �������� �������

            material.SetFloat("_Mode", 2); // ������������� ���������� �����
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha); // ������������� ����� �����
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha); // ������������� ������� ����� �����
            material.SetInt("_ZWrite", 0); // �������� ������ � ����� �������

            Color color = material.color; // �������� ���� ���������
            color.a = transparencyAmount; // ������������� ������� ������������
            material.color = color; // ��������� ���������
        }
    }
}
