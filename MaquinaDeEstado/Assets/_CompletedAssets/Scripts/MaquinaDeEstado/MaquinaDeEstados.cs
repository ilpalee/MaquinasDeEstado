using UnityEngine;
using System.Collections;

public class MaquinaDeEstados : MonoBehaviour {

    public MonoBehaviour EstadoPatrulla;
    public MonoBehaviour EstadoAlerta;
    public MonoBehaviour EstadoInicial;
    public MonoBehaviour EstadoMiedo;

    public MeshRenderer MeshRendererIndicador;

    private MonoBehaviour estadoActual;

    void Start () {
        ActivarEstado(EstadoInicial);
	}
	
    public void ActivarEstado(MonoBehaviour nuevoEstado)
    {
        if(estadoActual!=null) estadoActual.enabled = false;
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;
    }

}
