using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipObjectScript : MonoBehaviour
{
    public bool boolleft = false;
    public bool boolright = false;

    public void btnLeftClicked()
    {
        if (!boolleft)
        {
            boolleft = true;
            boolright = false;
            isleft();
        }
    }

    public void btnRightClicked()
    {
        if (!boolright)
        {
            boolright = true;
            boolleft = false;
            isright();
        }
    }

    private void isleft()
    {
        // ��� ��� ��� ���������� �������� ��� ������� ������ btnleft
        Debug.LogErrorFormat("Left");
    }

    private void isright()
    {
        // ��� ��� ��� ���������� �������� ��� ������� ������ btnright
        Debug.LogErrorFormat("Right");
    }
}
