/*********************************************
 * Data: 2023-09-14
 * Nome do Programador: Valdeir Antônio
 * Empresa: Oniria
 *********************************************/

using UnityEngine;

namespace Oniria.RocketTest
{
    /// <summary>
    /// Classe responsável por gerenciar comportamento do tanque de combustível.
    /// </summary>
    public class FuelTank : ISensor<float>
    {
        private float _currentCapacity;
        private readonly float _maxCapacity;
        public FuelTank(float capacity)
        {
            _maxCapacity = capacity;
            _currentCapacity = _maxCapacity;
        }
        public float GetCapacity()
        {
            return _maxCapacity;
        }
        public float GetValue()
        {
            return Mathf.Clamp((_currentCapacity/_maxCapacity), 0, 1);
        }
        /// <summary>
        /// Método responsável por consumir combustível do tanque.
        /// </summary>
        /// <param name="amount">Quantidade a ser consumida</param>
        public void Consume(float amount)
        {
            _currentCapacity -= amount;
        } 
    }
} 
