/*********************************************
 * Data: 2023-09-14
 * Nome do Programador: Valdeir Ant�nio
 * Empresa: Oniria
 *********************************************/
 
using TMPro; 
using UnityEngine;
using UnityEngine.UI;

namespace Oniria.RocketTest
{ 
    /// <summary>
    /// Classe respons�vel por gerenciar HUD do simulador.
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
        /// M�todo respons�vel por atualizar indicador de combust�vel.
        /// </summary>
        /// <param name="amount">Quantidade atual de combust�vel</param>
        public void FuelUpdateHUDs(float amount)
        {
            _fuelBar.fillAmount = amount;
            _fuelPercent.SetText($"{amount * 100:F2}%");
        }
        /// <summary>
        /// M�todo respons�vel por atualizar indicador de velocidade.
        /// </summary>
        /// <param name="speed">Velocidade atual do foguete</param>
        public void SpeedUpdateHUDs(float speed)
        {
            _speedHUD.SetText($"{speed:F2} km/s");
        }
        /// <summary>
        /// M�todo respons�vel por atualizar indicador de altitude.
        /// </summary>
        /// <param name="amount">Altitude atual do foguete</param>
        public void AltimeterUpdateHUDs(float amount) 
        {
            _altimeterHUD.SetText($"{amount/100:F3} km");
        }
    }
} 
