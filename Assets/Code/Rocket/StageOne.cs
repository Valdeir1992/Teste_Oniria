/*********************************************
 * Data: 2023-09-14
 * Nome do Programador: Valdeir Antônio
 * Empresa: Oniria
 *********************************************/
 
using UnityEngine;

namespace Oniria.RocketTest
{
    /// <summary>
    /// Classe responsãvel por gerenciar o comportamento do estágio um do foguete.
    /// </summary>
    public sealed class StageOne : Stage
    {  
        /// <summary>
        /// Método responsável liberar o estágio um.
        /// </summary>
        public void ReleageStage()
        {
            Destroy(GetComponent<FixedJoint>());
        }
    }
} 
