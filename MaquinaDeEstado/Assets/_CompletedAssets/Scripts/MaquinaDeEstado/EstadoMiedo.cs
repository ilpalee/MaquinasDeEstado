using UnityEngine;
using System.Collections;

public class EstadoMiedo : MonoBehaviour
{

    public Transform WayPointMiedo;
    public Color ColorEstado = Color.black;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;

    void Awake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
    }

    void OnEnable()
    {
        maquinaDeEstados.MeshRendererIndicador.material.color = ColorEstado;
    }

    void Update()
    {
        RaycastHit hit;
        if (!controladorVision.PuedeVerAlJugador(out hit, true))
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
            return;
        }

        navMeshAgent.speed = 7f;
        navMeshAgent.angularSpeed = 250f;
        navMeshAgent.acceleration = 15f;
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent(WayPointMiedo.position);

    }



}
