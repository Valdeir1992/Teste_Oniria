/*********************************************
 * Data: 2023-09-14
 * Nome do Programador: Valdeir Antônio
 * Empresa: Oniria
 *********************************************/

using System; 
using UnityEngine;

namespace Oniria.RocketTest
{
    /// <summary>
    /// Classe responsável por controlar o comportamento do foguete.
    /// </summary>
    public class RocketController : MonoBehaviour
    {
        public Action<float> ChangeAltimetre;
        public Action<float> WhenMoving;
        public Action<float> WhenConsumeFuel;
        private ISensor<float> _altimeter;
        [SerializeField] private Stage _stageOne;
        [SerializeField] private Stage _stageTwo;

        private void Awake()
        {
            _altimeter = _stageTwo.GetComponent<ISensor<float>>(); 

            _stageOne.WhenOutOfGas += () =>
            {
                (_stageOne as StageOne).ReleageStage();
                _stageTwo.ActiveEngine();
            };
        }
        private void Start()
        {
            _stageOne.ActiveEngine();
        }

        private void Update()
        { 
            if (!ReferenceEquals(WhenConsumeFuel, null))
            {
                float maxCapacity = _stageTwo.Tank.GetCapacity() + _stageOne.Tank.GetCapacity();
                float currentCapacity = (_stageOne.Tank.GetValue() * _stageOne.Tank.GetCapacity()) + (_stageTwo.Tank.GetValue() * _stageTwo.Tank.GetCapacity());
                WhenConsumeFuel?.Invoke(currentCapacity / maxCapacity);
            }
            if(!ReferenceEquals(WhenMoving, null))
            {
                WhenMoving?.Invoke(_stageOne.Speed);
            }
            if (!ReferenceEquals(ChangeAltimetre, null))
            {
                ChangeAltimetre?.Invoke(_altimeter.GetValue());
            }
        } 
    }
} 
