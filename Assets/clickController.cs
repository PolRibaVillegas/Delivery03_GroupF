using UnityEngine;

public class ClickSelector : MonoBehaviour
{
    public GameObject selectedObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                selectedObject = hit.collider.gameObject;
                Debug.Log("Seleccionado: " + selectedObject.name);
            }
        }
    }

    public void PerformAction()
    {
        if (selectedObject != null)
        {
            Debug.Log("Acción realizada en: " + selectedObject.name);
            selectedObject.transform.localScale *= 1.2f; // Ejemplo: Cambiar tamaño
        }
    }
}

