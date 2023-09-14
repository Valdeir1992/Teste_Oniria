/*********************************************
 * Data: 2023-09-14
 * Nome do Programador: Valdeir Antônio
 * Empresa: Oniria
 *********************************************/
 

namespace Oniria.RocketTest
{
    /// <summary>
    /// Interface base para implementação de sensores.
    /// </summary>
    /// <typeparam name="T">Qualquer valor que deve ser retornado pelo sensor</typeparam>
    public interface ISensor<T>
    {
        /// <summary>
        /// Método responsável por retornar valor para aferição.
        /// </summary>
        /// <returns></returns>
        public T GetValue();
    }
} 
