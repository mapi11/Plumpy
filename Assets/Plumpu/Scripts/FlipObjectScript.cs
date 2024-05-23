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
        // Ваш код для выполнения действий при нажатии кнопки btnleft
        Debug.LogErrorFormat("Left");
    }

    private void isright()
    {
        // Ваш код для выполнения действий при нажатии кнопки btnright
        Debug.LogErrorFormat("Right");
    }
}
