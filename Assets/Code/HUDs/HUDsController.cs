/*********************************************
 * Data: 2023-09-14
 * Nome do Programador: Valdeir Antônio
 * Empresa: Oniria
 *********************************************/
 
using TMPro; 
using UnityEngine;
using UnityEngine.UI;

namespace Oniria.RocketTest
{ 
    /// <summary>
    /// Classe responsãvel por gerenciar HUD do simulador.
    /// </summary>
    public class HUDsController : MonoBehaviour
    {
        [SerializeField] private Image _fuelBar;
        [SerializeField] private TextMeshProUGUI _fuelPercent;
        [SerializeField] private TextMeshProUGUI _speedHUD;
        [SerializeField] private TextMeshProUGUI _altimeterHUD;

        private void Awake()
        {
            var rocketController = FindAnyObjectByType<RocketController>();
            rocketController.WhenConsumeFuel += FuelUpdateHUDs;
            rocketController.WhenMoving += SpeedUpdateHUDs;
            rocketController.ChangeAltimetre += AltimeterUpdateHUDs;
        }

        /// <summary>
        /// Método responsãvel por atualizar indicador de combustível.
        /// </summary>
        /// <param name="amount">Quantidade atual de combustível</param>
        public void FuelUpdateHUDs(float amount)
        {
            _fuelBar.fillAmount = amount;
            _fuelPercent.SetText($"{amount * 100:F2}%");
        }
        /// <summary>
        /// Método responsável por atualizar indicador de velocidade.
        /// </summary>
        /// <param name="speed">Velocidade atual do foguete</param>
        public void SpeedUpdateHUDs(float speed)
        {
            _speedHUD.SetText($"{speed:F2} km/s");
        }
        /// <summary>
        /// Método responsãvel por atualizar indicador de altitude.
        /// </summary>
        /// <param name="amount">Altitude atual do foguete</param>
        public void AltimeterUpdateHUDs(float amount) 
        {
            _altimeterHUD.SetText($"{amount/100:F3} km");
        }
    }
} 
