/*********************************************
 * Data: 2023-09-14
 * Nome do Programador: Valdeir Ant�nio
 * Empresa: Oniria
 *********************************************/

using Cysharp.Threading.Tasks;  
using UnityEngine; 

namespace Oniria.RocketTest
{
    /// <summary>
    /// Classe respons�vel por gerenciar o menu inicial.
    /// </summary>
    public class MenuController : MonoBehaviour
    {

        /// <summary>
        /// M�todo respons�vel por carregar asincronamente a cena.
        /// </summary>
        /// <param name="name">Nome da cena que ser� carregada</param>
        /// <returns></returns>
        private async UniTask Load(string name)
        {
            await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(name, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }

        /// <summary>
        /// M�todo que inicializar carregamento de cena.
        /// </summary>
        /// <param name="name"></param>
        public void LoadScene(string name)
        {
            Load(name);
        }

    }
}
