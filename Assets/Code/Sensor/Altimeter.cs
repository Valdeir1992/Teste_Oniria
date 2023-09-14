/*********************************************
 * Data: 2023-09-14
 * Nome do Programador: Valdeir Antônio
 * Empresa: Oniria
 *********************************************/

using UnityEngine;

namespace Oniria.RocketTest
{
    /// <summary>
    /// Classe responsável por retornar altitude do foguete.
    /// </summary>
    public sealed class Altimeter :MonoBehaviour, ISensor<float>
    {
        private Vector3 _startPosition; 

        private void Awake()
        {
            _startPosition = transform.position;
        }
        public float GetValue()
        {
            return (transform.position.y-_startPosition.y);
        }
    }
} 
