using System.Diagnostics;

namespace tpfinal
{
    public class Estrategia
	{
        /// <summary>
        /// Compara el tiempo de ejecución de dos métodos de búsqueda: BuscarConHeap y BuscarConOtro.
        /// Realiza la comparación en base a múltiples repeticiones para obtener un promedio.
        /// </summary>
        /// <param name="datos">Lista de datos de entrada.</param>
        /// <returns>Cadena con los tiempos promedio de ejecución de ambos métodos.</returns>
        public String Consulta1(List<string> datos)
		{
            // Número de repeticiones para mayor precisión
            int repeticiones = 5;
            List<double> tiemposHeap = new List<double>();
            List<double> tiemposOtro = new List<double>();

            // Repetir las pruebas varias veces para calcular un tiempo promedio.
            for (int i = 0; i < repeticiones; i++)
            {
                // Medir el tiempo de ejecución de BuscarConHeap
                List<Dato> heapResult = new List<Dato>();
                Stopwatch heapStopwatch = Stopwatch.StartNew();
                BuscarConHeap(datos, 5, heapResult);
                heapStopwatch.Stop();
                tiemposHeap.Add(heapStopwatch.Elapsed.TotalMilliseconds);

                // Medir el tiempo de ejecución de BuscarConOtro
                List<Dato> otroResult = new List<Dato>();
                Stopwatch otroStopwatch = Stopwatch.StartNew();
                BuscarConOtro(datos, 5, otroResult);
                otroStopwatch.Stop();
                tiemposOtro.Add(otroStopwatch.Elapsed.TotalMilliseconds);
            }

            // Promediar los tiempos de ejecución
            double promedioHeap = tiemposHeap.Average();
            double promedioOtro = tiemposOtro.Average();

            // Crear el texto de salida con los resultados promedio.
            string result = $"Tiempo promedio de \"Buscar Con Heap\": {promedioHeap:F4} ms\n";
            result += $"Tiempo promedio de \"Buscar Con Otro\": {promedioOtro:F4} ms";
            return result;
        }

        /// <summary>
        /// Retorna un texto con el camino a la hoja más izquierda de la Heap que se construye a partir de los datos de entrada cuando se utiliza el métodoBuscarConHeap()
        /// </summary>
        /// <param name="datos">Lista de datos de entrada.</param>
        /// <returns>Cadena que representa el camino a la hoja más izquierda.</returns>
        public String Consulta2(List<string> datos)
		{
            // Crear una instancia de HeapSort y contar las ocurrencias en los datos.
            HeapSort heap = new HeapSort();
            Dictionary<string, int> conteo = MaxCountDate(datos);
            heap.Sort(conteo);

            // Convertir el diccionario ordenado en una lista de pares clave-valor
            var arr = new List<KeyValuePair<string, int>>(conteo);

            // Construir el camino a la hoja más a la izquierda
            List<string> camino = new List<string>();
            int i = 0;
            while (i < arr.Count)
            {
                camino.Add(arr[i].Key);
                i = 2 * i + 1; // Ir al hijo izquierdo segun prop del arbol binario
            }

            return string.Join(" -> ", camino);
        }

        /// <summary>
        /// Retorna un texto que contiene los datos de la Heap que se construye a partir de los datos de entrada cuando se utiliza el método BuscarConHeap(), 
        /// explicitando en el texto resultado los niveles en los que se encuentran ubicados cada uno de los datos.
        /// </summary>
        /// <param name="datos">Lista de datos de entrada.</param>
        /// <returns>Cadena que representa los datos ordenados por niveles.</returns>
        public String Consulta3(List<string> datos)
		{
            // Crear una instancia de HeapSort y contar las ocurrencias en los datos.
            HeapSort heap = new HeapSort();
            Dictionary<string, int> conteo = MaxCountDate(datos);
            heap.Sort(conteo);

            // Convertir el diccionario ordenado en una lista de pares clave-valor
            var arr = new List<KeyValuePair<string, int>>(conteo);

            // Construir el texto con los niveles
            var niveles = new Dictionary<int, List<string>>();
            for (int i = 0; i < arr.Count; i++)
            {
                int nivel = (int)Math.Floor(Math.Log(i + 1, 2));
                if (!niveles.ContainsKey(nivel))
                {
                    niveles[nivel] = new List<string>();
                }
                niveles[nivel].Add(arr[i].Key);
            }

            // Formatear el resultado mostrando los datos por niveles.
            var resultado = new List<string>();
            foreach (var nivel in niveles)
            {
                resultado.Add($"Nivel {nivel.Key}: {string.Join(", ", nivel.Value)}");
            }

            return string.Join("\n", resultado);
        }

        /// <summary>
        /// Retorna en la variable collected los primeros elementos con mayor número de ocurrencias de la lista datos utilizando una Heap como estructura de datos soporte. 
        /// El número de elementos a retornar es indicado por el parámetro cantidad.
        /// </summary>
        /// <param name="datos">Lista de datos de entrada.</param>
        /// <param name="cantidad">Número de elementos a retornar.</param>
        /// <param name="collected">Lista que almacenará los elementos encontrados.</param>
        public void BuscarConHeap(List<string> datos, int cantidad, List<Dato> collected)
        {
            // Validar los parámetros de entrada.
            if (datos == null || cantidad <= 0)
                return;

            // Crear una instancia de HeapSort y contar las ocurrencias en los datos.
            HeapSort heap = new HeapSort();
            Dictionary<string, int> conteo = MaxCountDate(datos);
            heap.Sort(conteo);

            // Extraer los datos con mayor número de ocurrencias hasta alcanzar la cantidad deseada
            foreach (var kvp in conteo)
            {
                if (collected.Count < cantidad)
                {
                    collected.Add(new Dato(kvp.Value, kvp.Key));
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Retorna en la variable collected los primeros elementos con mayor número de ocurrencias de la lista datos.
        /// El número de elementos a retornar es indicado por el parámetro cantidad.
        /// </summary>
        /// <param name="datos">Lista de datos de entrada.</param>
        /// <param name="cantidad">Número de elementos a retornar.</param>
        /// <param name="collected">Lista que almacenará los elementos encontrados.</param>
        public void BuscarConOtro(List<string> datos, int cantidad, List<Dato> collected)
        {
            // Validar los parámetros de entrada.
            if (datos == null || cantidad <= 0)
                return;

            // Contar las ocurrencias en los datos.
            Dictionary<string, int> conteo = MaxCountDate(datos);

            // Ordenar el diccionario por el número de ocurrencias de forma descendente
            var sortedDict = conteo.OrderByDescending(x => x.Value);

            // Extraer los datos con mayor número de ocurrencias hasta alcanzar la cantidad deseada
            foreach (var kvp in sortedDict)
            {
                if (collected.Count < cantidad)
                {
                    collected.Add(new Dato(kvp.Value, kvp.Key));
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Método auxiliar para contar las ocurrencias de cada elemento en la lista de datos.
        /// Genera un diccionario con la clave valor de los elementos sin repetir y la cantidad de repeticiones
        /// </summary>
        /// <param name="datos"></param>
        /// <returns>Lista de datos de entrada.</returns>
        private Dictionary<string, int> MaxCountDate(List<string> datos)
        {
            Dictionary<string, int> conteo = new Dictionary<string, int>();

            // Calcular el recuento de ocurrencias para cada elemento en datos
            foreach (string dato in datos)
            {
                if (conteo.ContainsKey(dato))
                    conteo[dato]++;
                else
                    conteo[dato] = 1;
            }

            return conteo;
        }
	}
}