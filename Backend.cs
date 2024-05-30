namespace tpfinal
{
    public class Backend
    {
        public static List<string> datos = new List<string>();

        /// <summary>
        /// Realiza una consulta en profundidad utilizando la estrategia definida.
        /// </summary>
        /// <returns>El resultado de la consulta en profundidad como una cadena.</returns>
        public static string aProfundidad()
        {
            // Crea una nueva instancia de la clase Estrategia y llama al método Consulta3 pasando los datos.
            return (new Estrategia()).Consulta3(datos);
        }

        /// <summary>
        /// Realiza una consulta para obtener el camino hacia una predicción utilizando la estrategia definida.
        /// </summary>
        /// <returns>El resultado del camino hacia la predicción como una cadena.</returns>
        public static string caminoAPrediccion()
        {
            // Crea una nueva instancia de la clase Estrategia y llama al método Consulta2 pasando los datos.
            return (new Estrategia()).Consulta2(datos);
        }

        /// <summary>
        /// Realiza una consulta para obtener todas las predicciones posibles utilizando la estrategia definida.
        /// </summary>
        /// <returns>El resultado de todas las predicciones como una cadena.</returns>
        public static string todasLasPredicciones()
        {
            // Crea una nueva instancia de la clase Estrategia y llama al método Consulta1 pasando los datos.
            return (new Estrategia()).Consulta1(datos);
        }

        /// <summary>
        /// Busca datos utilizando una de dos estrategias dependiendo del valor de heapOP.
        /// </summary>
        /// <param name="heapOP">Indica si se debe utilizar el método de búsqueda con heap (true) o el otro método (false).</param>
        /// <param name="cantidad">La cantidad de resultados deseados.</param>
        /// <param name="collected">La lista de objetos Dato donde se almacenarán los resultados encontrados.</param>
        public static void buscar(bool heapOP, int cantidad, List<Dato> collected)
        {
            // Si heapOP es verdadero, utiliza la estrategia de búsqueda con heap.
            if (heapOP)
            {
                // Crea una nueva instancia de la clase Estrategia y llama al método BuscarConHeap pasando los datos, cantidad y la lista para almacenar resultados.
                (new Estrategia()).BuscarConHeap(datos, cantidad, collected);
            }
            // Si heapOP es falso, utiliza la otra estrategia de búsqueda.
            else
            {
                // Crea una nueva instancia de la clase Estrategia y llama al método BuscarConOtro pasando los datos, cantidad y la lista para almacenar resultados.
                (new Estrategia()).BuscarConOtro(datos, cantidad, collected);
            }
        }
    }
}