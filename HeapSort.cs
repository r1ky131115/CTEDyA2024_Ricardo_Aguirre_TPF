namespace tpfinal
{
    public class HeapSort
    {
        /// <summary>
        /// Ordena los elementos de un diccionario de acuerdo a sus valores.
        /// </summary>
        /// <param name="dict"></param>
        public void Sort(Dictionary<string, int> dict)
        {
            // Crear una lista que contiene pares clave-valor a partir del diccionario.
            var arr = new List<KeyValuePair<string, int>>(dict);

            // Obtener la cantidad de elementos en la lista.
            int n = arr.Count;

            // Construir un heap máximo.
            // Este bucle comienza desde el medio de la lista hacia atrás.
            // El propósito es reorganizar la lista para que cumpla con las propiedades de un heap.
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                // Asegurarse de que la subárbol con raíz en el índice 'i' sea un heap.
                Heapify(arr, n, i);
            }

            // Ordenar la lista usando la técnica de heap sort.
            // Este bucle recorre la lista de atrás hacia adelante.
            for (int i = n - 1; i >= 0; i--)
            {
                // Intercambiar el primer elemento (máximo) con el último elemento no ordenado.
                var temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // Volver a formar el heap con los elementos restantes.
                Heapify(arr, i, 0);
            }

            // Limpiar el diccionario original para llenarlo con los elementos ordenados.
            dict.Clear();

            //Min Heap
            /*foreach (var kvp in arr)
            {
                dict.Add(kvp.Key, kvp.Value);
            }*/

            // Agregar los elementos ordenados al diccionario en orden inverso para mantener el orden de máx heap.
            for (int i = n - 1; i >= 0; i--)
            {
                dict.Add(arr[i].Key, arr[i].Value);
            }
        }

        /// <summary>
        /// Ayuda a mantener la propiedad del montículo (heap) para un subárbol específico en la lista.
        /// Reorganiza la lista para que el subárbol con raíz en el índice 'i' cumpla con las propiedades de un heap máximo.
        /// </summary>
        /// <param name="arr">La lista de pares clave-valor que representa el heap.</param>
        /// <param name="n">El tamaño del heap.</param>
        /// <param name="i">El índice de la raíz del subárbol que se va a heapificar.</param>
        private void Heapify(List<KeyValuePair<string, int>> arr, int n, int i)
        {
            // Inicializar el índice del mayor valor como la raíz.
            int largest = i;
            int l = 2 * i + 1; //hijo izquierdo
            int r = 2 * i + 2; //hijo derecho

            // Si el hijo izquierdo es mayor que la raíz.
            if (l < n && arr[l].Value > arr[largest].Value)
                largest = l;

            // Si el mayor no es la raíz, intercambiar con el mayor y continuar heapificando.
            if (r < n && arr[r].Value > arr[largest].Value)
                largest = r;

            // Swap and continue heapifying if root is not largest
            if (largest != i)
            {
                // Intercambiar los elementos en los índices 'i' y 'largest'.
                var swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Recursivamente aplicar heapify al subárbol afectado.
                Heapify(arr, n, largest);
            }
        }
    }
}
