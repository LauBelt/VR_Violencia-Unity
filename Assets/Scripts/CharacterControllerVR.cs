using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterControllerVR : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform destination; // Asigna un objeto vacío en la escena que marque el destino
    private Animator animator;
    void Awake()
    {
        // Obtener componentes
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
    }

    public void StartWalking()
    {
        // Activa la animación de caminar
        if (animator != null)
        {
            animator.SetTrigger("Walk");
        }

        // Configura el destino del agente
        if (agent != null && destination != null)
        {
            agent.SetDestination(destination.position);
        }
    }
}
