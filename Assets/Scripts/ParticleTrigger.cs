using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    // Referencia al sistema de partículas
    public ParticleSystem psExplosion;
    public ParticleSystem psExplosionRocas;
    public ParticleSystem psExplosionTierra;
    public ParticleSystem psExplosionHumo;
    public ParticleSystem psExplosionPolvo;
    public ParticleSystem psATShoot;


    // Tiempo de espera en segundos antes de activar el sistema de partículas
    public float delayTime = 5.0f;
    public float delayTimeATShoot = 5.0f;

    public float delayTimeAT = 5.0f;
    // Inicia la corrutina cuando empieza el juego o el objeto es activado
    void Start()
    {
        // Llamar a la corrutina para activar el sistema de partículas después de un retraso
        StartCoroutine(ActivateParticlesPeriodically());
        StartCoroutine(ActivateParticlesATShoot());
    }

    

    // Corrutina que espera el tiempo especificado antes de activar el sistema de partículas
    IEnumerator ActivateParticlesPeriodically()
    {
        // Bucle infinito para que las partículas se activen periódicamente
        while (true)
        {
            // Esperar el tiempo especificado
            yield return new WaitForSeconds(delayTime);

            // Activar todas las partículas
            psExplosion.Play();
            psExplosionRocas.Play();
            psExplosionTierra.Play();
            psExplosionHumo.Play();
            psExplosionPolvo.Play();
        }
    }

    IEnumerator ActivateParticlesATShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayTimeATShoot);

            psATShoot.Play();
        }
    }
}
