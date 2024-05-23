using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyController : MonoBehaviour
{
    public float transparencyAmount = 0.5f; // задаем уровень прозрачности

    public Renderer[] renderers;

    //public Renderer[] _renderers;

    void Start()
    {
        //_renderers = renderers;

        foreach (Renderer renderer in renderers)
        {
            Material material = renderer.material; // получаем материал объекта

            material.SetFloat("_Mode", 2); // устанавливаем прозрачный режим
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha); // устанавливаем альфа канал
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha); // устанавливаем целевой альфа канал
            material.SetInt("_ZWrite", 0); // включаем запись в буфер глубины

            Color color = material.color; // получаем цвет материала
            color.a = transparencyAmount; // устанавливаем уровень прозрачности
            material.color = color; // сохраняем изменения
        }
    }
}
