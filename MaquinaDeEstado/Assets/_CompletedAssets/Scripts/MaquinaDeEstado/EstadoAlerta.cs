using UnityEngine;
using System.Collections;

public class EstadoAlerta : MonoBehaviour {

    public float velocidadGiroBusqueda = 250f;
    public float duracionBusqueda = 4f;
    public Color ColorEstado = Color.yellow;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;
    private float tiempoBuscando;

	void Awake () {

        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        
    }

    void OnEnable()
    {
        maquinaDeEstados.MeshRendererIndicador.material.color = ColorEstado;
        controladorNavMesh.DetenerNavMeshAgent();
        tiempoBuscando = 0f;
        navMeshAgent.speed = 2.5f;
        navMeshAgent.angularSpeed = 120f;
        navMeshAgent.acceleration = 8f;
    }
	
	void Update () {
        RaycastHit hit;
        if (controladorVision.PuedeVerAlJugador(out hit))
        {
            controladorNavMesh.perseguirObjectivo = hit.transform;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoMiedo);
            return;
        }

        transform.Rotate(0f, velocidadGiroBusqueda * Time.deltaTime, 0f);
        tiempoBuscando += Time.deltaTime;
        if(tiempoBuscando >= duracionBusqueda)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPatrulla);
            return;
        }
	}
}
