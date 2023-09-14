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
    /// Classe responsãvel por gerenciar o comportamento do estágio dois do foguete.
    /// </summary>
    public sealed class StageTwo : Stage
    {
        [SerializeField] private Vector3 _centerOfMass;
        [SerializeField] private Transform _parachute;

        private void Start()
        {
            WhenOutOfGas += () => OpenParachute(); 
        } 
        /// <summary>
        /// Método responsãvel por ativar o para-queda.
        /// </summary>
        /// <returns></returns>
        private async UniTask OpenParachute()
        {
            Quaternion quaternion = transform.rotation; 
            body.centerOfMass = _centerOfMass;  
            for (float i = 0; i < 1; i+=Time.deltaTime)
            { 
                _parachute.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i); 
                await UniTask.Yield();
            } 
            Vector3 currentVelocity = body.velocity;
            while (currentVelocity.sqrMagnitude > 0)
            { 
                currentVelocity = Vector3.MoveTowards(currentVelocity, new Vector3(0, 0, 0), Time.deltaTime * 3);
                body.velocity = currentVelocity;
                await UniTask.NextFrame();
            }   
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position + transform.rotation * _centerOfMass, 0.4f);
        }

        public override UniTask ActiveEngine()
        { 
            return base.ActiveEngine();
        }
    }
} 
