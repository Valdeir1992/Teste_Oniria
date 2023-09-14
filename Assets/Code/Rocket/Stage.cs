/*********************************************
 * Data: 2023-09-14
 * Nome do Programador: Valdeir Antônio
 * Empresa: Oniria
 *********************************************/

using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace Oniria.RocketTest
{
    /// <summary>
    /// Classe base repsonsável por gerenciar o comportamentos do estágio do foguete;
    /// </summary>
    [RequireComponent(typeof(Rigidbody),typeof(CapsuleCollider))]
    public abstract class Stage : MonoBehaviour
    {
        public Action WhenOutOfGas;

        public FuelTank Tank
        {
            get => _tank;
        }

        public float Speed
        {
            get => body.velocity.magnitude;
        }
         
        protected Rigidbody body;
        private FuelTank _tank; 
        [SerializeField] protected ParticleSystem engineParticles;
        [SerializeField] protected AudioSource engineAudioSource;
        [SerializeField] private float _initialFuel;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _engineStrength;
        [SerializeField] private float _fuelConsumptionRate;

        private void Awake()
        { 
            body = GetComponent<Rigidbody>();
            _tank = new FuelTank(_initialFuel);
        }

        /// <summary>
        /// Método responsável por controlar o comportamento do propulsor do estágio.
        /// </summary>
        /// <returns></returns>
        public virtual async UniTask ActiveEngine()
        {
            engineParticles.Play();
            engineAudioSource.Play();

            float currentStrenght = 0;

            while (_tank.GetValue() > 0)
            {
                currentStrenght = Mathf.MoveTowards(currentStrenght, _engineStrength, _acceleration * Time.deltaTime); 
                _tank.Consume(Time.deltaTime * _fuelConsumptionRate); 
                body.AddForce(transform.TransformDirection(Vector3.forward) * currentStrenght,ForceMode.Impulse);  
                await UniTask.NextFrame();
            } 

            engineParticles.Stop();
            engineAudioSource.Stop();

            if (!ReferenceEquals(WhenOutOfGas, null))
            {
                WhenOutOfGas?.Invoke();
            }
        }
    }
} 
