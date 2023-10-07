using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObjeto : MonoBehaviour
{
    public float velocidadRotacion = 5.0f;


    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

        transform.position = Vector3.Lerp(transform.position, worldPosition, Time.deltaTime * velocidadRotacion);

    }
}
