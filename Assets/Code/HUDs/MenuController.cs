/*********************************************
 * Data: 2023-09-14
 * Nome do Programador: Valdeir Antônio
 * Empresa: Oniria
 *********************************************/

using Cysharp.Threading.Tasks;  
using UnityEngine; 

namespace Oniria.RocketTest
{
    /// <summary>
    /// Classe responsãvel por gerenciar o menu inicial.
    /// </summary>
    public class MenuController : MonoBehaviour
    {

        /// <summary>
        /// Método responsãvel por carregar asincronamente a cena.
        /// </summary>
        /// <param name="name">Nome da cena que será carregada</param>
        /// <returns></returns>
        private async UniTask Load(string name)
        {
            await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(name, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }

        /// <summary>
        /// Método que inicializar carregamento de cena.
        /// </summary>
        /// <param name="name"></param>
        public void LoadScene(string name)
        {
            Load(name);
        }

    }
}
