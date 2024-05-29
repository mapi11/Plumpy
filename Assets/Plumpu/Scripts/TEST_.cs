using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ : MonoBehaviour
{
    //[HideInInspector]
    private static List<GameObject> taggedObjects1 = new List<GameObject>();
    //[HideInInspector]
    private static List<GameObject> taggedObjects2 = new List<GameObject>();

    public List<GameObject> tags1 => taggedObjects1;
    public List<GameObject> tags2 => taggedObjects2;

    [Space]
    [Header("Fade objects")]
    //public Renderer[] renderers1D;
    //public Renderer[] renderers3D;

    public Material shaderMaterial_1D;
    public Material shaderMaterial_3D;
    public float minAlpha = 0.3f;
    public float maxAlpha = 1f;
    public float fadeDuration = 2f;

    private float currentAlpha_1D;
    private float targetAlpha_1D;
    private float currentAlpha_3D;
    private float targetAlpha_3D;
    private float fadeTimer_1D;
    private float fadeTimer_3D;

    [Space]
    public List<Renderer> fade1DObjects1D = new List<Renderer>();
    public List<Renderer> fade1DObjects3D = new List<Renderer>();

    [HideInInspector]
    public GameObject[] objectsWithTag1D;
    [HideInInspector]
    public GameObject[] objectsWithTag3D;

    public static void AddObject(GameObject obj ,ObjectTags tag)
    {
        switch (tag)
        {
            case ObjectTags.Obj1D:
                if (!taggedObjects1.Contains(obj))
                {
                    taggedObjects1.Add(obj);
                }
                break;
            case ObjectTags.Obj2D:
                if (!taggedObjects2.Contains(obj))
                {
                    taggedObjects2.Add(obj);
                }
                break;
        }
    }



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


        // ----------------------------------------------------------------------------------Fade objects

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

        //----------------------------------------------------------------------------------Fade sprite
        currentAlpha_1D = 1;
        currentAlpha_3D = 1;

        currentAlpha_1D = maxAlpha;
        targetAlpha_1D = maxAlpha;
        fadeTimer_1D = 0f;

        currentAlpha_3D = maxAlpha;
        targetAlpha_3D = maxAlpha;
        fadeTimer_3D = 0f;
    }

    void Start()
    {


    }

    void Update()
    {
        //// Проверка на удаление элемента со сцены
        //taggedObjects1.RemoveAll(item => item == null);
        //taggedObjects2.RemoveAll(item => item == null);

        // Проверка на появление новых элементов


        //--------------------------------------------------------------------------------------
        //GameObject[] objectsWithTag1D = GameObject.FindGameObjectsWithTag("Obj1D");
        //GameObject[] objectsWithTag2D = GameObject.FindGameObjectsWithTag("Obj2D");

        //foreach (GameObject obj in objectsWithTag1D)
        //{
        //    if (!taggedObjects1.Contains(obj))
        //    {
        //        taggedObjects1.Add(obj);
        //        Debug.Log("Added" + taggedObjects1.Count);
        //    }
        //    else
        //    {
        //        taggedObjects1.RemoveAll(item => item == null);
        //    }
        //}

        //foreach (GameObject obj in objectsWithTag2D)
        //{
        //    if (!taggedObjects2.Contains(obj))
        //    {
        //        taggedObjects2.Add(obj);
        //        Debug.Log("Added" + taggedObjects2.Count);
        //    }
        //    else
        //    {
        //        taggedObjects2.RemoveAll(item => item == null);
        //    }
        //}
        if (fadeTimer_1D < fadeDuration)
        {
            fadeTimer_1D += Time.deltaTime;

            float t = fadeTimer_1D / fadeDuration;
            currentAlpha_1D = Mathf.Lerp(currentAlpha_1D, targetAlpha_1D, t);

            shaderMaterial_1D.SetFloat("_AlphaValue", currentAlpha_1D);
        }
        if (fadeTimer_3D < fadeDuration)
        {
            fadeTimer_3D += Time.deltaTime;

            float t = fadeTimer_3D / fadeDuration;
            currentAlpha_3D = Mathf.Lerp(currentAlpha_3D, targetAlpha_3D, t);

            shaderMaterial_3D.SetFloat("_AlphaValue", currentAlpha_3D);
        }
    }

    public void FadeObjects1D(float _transparencyAmount1D)
    {
        foreach (Renderer renderer in fade1DObjects1D)
        {
            //Material material = renderer.material; // получаем материал объекта

            //material.SetFloat("_Mode", 2); // устанавливаем прозрачный режим
            //material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha); // устанавливаем альфа канал
            //material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha); // устанавливаем целевой альфа канал
            //material.SetInt("_ZWrite", 0); // включаем запись в буфер глубины

            //Color _Color = material.color; // получаем цвет материала
            //_Color.a = _transparencyAmount1D; // устанавливаем уровень прозрачности
            //material.color = _Color; // сохраняем изменения
        }
    }

    public void FadeObjects3D(float _transparencyAmount3D)
    {
        foreach (Renderer renderer in fade1DObjects3D)
        {
            //Material material = renderer.material; // получаем материал объекта

            //material.SetFloat("_Mode", 2); // устанавливаем прозрачный режим
            //material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha); // устанавливаем альфа канал
            //material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha); // устанавливаем целевой альфа канал
            //material.SetInt("_ZWrite", 0); // включаем запись в буфер глубины

            //Color _Color = material.color; // получаем цвет материала
            //_Color.a = _transparencyAmount3D; // устанавливаем уровень прозрачности
            //material.color = _Color; // сохраняем изменения
        }
    }

    public void FadeOn1D()
    {
        targetAlpha_1D = minAlpha;
        fadeTimer_1D = 0f;
    }

    public void FadeOff1D()
    {
        targetAlpha_1D = maxAlpha;
        fadeTimer_1D = 0f;
    }
    public void FadeOn3D()
    {
        targetAlpha_3D = minAlpha;
        fadeTimer_3D = 0f;
    }

    public void FadeOff3D()
    {
        targetAlpha_3D = maxAlpha;
        fadeTimer_3D = 0f;
    }
}

public enum ObjectTags
{
    Obj1D = 0, 
    Obj2D = 1, 
    Obj3D = 2
}