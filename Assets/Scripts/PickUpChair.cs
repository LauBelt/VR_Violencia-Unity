using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpChair : MonoBehaviour
{
    public GameObject chairToPickup; 
    public string handBoneName = "RightHand";
    private Transform handTransform;
    
    public void Pickup()
    {
        if (chairToPickup == null)
        {
            Debug.LogError("No se ha asignado la silla a recoger.");
            return;
        }

        // Busca el hueso de la mano en los hijos del personaje
        Transform characterTransform = transform; // Suponiendo que este script está en el personaje
        handTransform = FindDeepChild(characterTransform, handBoneName);

        if (handTransform == null)
        {
            Debug.LogError("No se encontró el hueso de la mano con el nombre: " + handBoneName);
            return;
        }

        // Emparenta la silla a la mano
        chairToPickup.transform.SetParent(handTransform);

        // Opcional: Ajusta la posición y rotación local de la silla para que se vea bien en la mano
        chairToPickup.transform.localPosition = Vector3.zero; // Puedes ajustar estos valores
        chairToPickup.transform.localRotation = Quaternion.identity; // Puedes ajustar estos valores
    }

    // Función auxiliar para buscar un hijo en profundidad por su nombre
    public static Transform FindDeepChild(Transform aParent, string aName)
    {
        var result = aParent.Find(aName);
        if (result != null)
            return result;
        foreach (Transform child in aParent)
        {
            result = FindDeepChild(child, aName);
            if (result != null)
                return result;
        }
        return null;
    }
}
