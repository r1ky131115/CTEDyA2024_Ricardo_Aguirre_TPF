# Trabajo Final 2024 - Complejidad Temporal en Estructura de Datos y Algoritmos

[Introducción]
Este informe tiene como objetivo presentar el desarrollo e implementación de un buscador de máximas ocurrencias para una empresa informática. El buscador analiza conjuntos de datos almacenados en archivos CSV y determina cuáles son los elementos que aparecen con mayor frecuencia en dichos conjuntos. La aplicación está diseñada para ser intuitiva y fácil de usar, permitiendo a los usuarios seleccionar métodos de búsqueda y configurar la cantidad de resultados a mostrar.

La aplicación utiliza dos enfoques distintos: uno basado en el uso de una Heap y otro mediante un método alternativo. La inclusión de estos dos métodos enriquece las funcionalidades del buscador y permite comparar cuál de los dos es más óptimo para esta tarea específica. Esta dualidad de métodos de búsqueda es fundamental para evaluar la eficiencia y efectividad de cada enfoque, proporcionando información valiosa para futuras decisiones de implementación y optimización de las herramientas de análisis de datos.

[Descripción del Aplicativo]
Al iniciar la aplicación, el usuario debe seleccionar un archivo CSV que contiene los datos a analizar. La aplicación lee los datos del archivo y construye una lista de cadenas de texto (List<string>) a partir de la información contenida. Posteriormente, se despliega una interfaz donde el usuario puede realizar distintas búsquedas siguiendo estos pasos:

Selección del Método de Búsqueda: El usuario puede elegir entre utilizar una Heap o un método alternativo.
Configuración de Resultados: Se puede ajustar la cantidad de resultados a mostrar mediante una barra deslizante etiquetada como “Resultados”.
Ejecución de la Búsqueda: Al activar el botón “Buscar”, la aplicación realiza la búsqueda seleccionada.
Funcionamiento del Botón "Buscar"
El botón "Buscar" en la interfaz de la aplicación permite al usuario iniciar el proceso de búsqueda de los elementos con mayor número de ocurrencias en el conjunto de datos seleccionado. A continuación, se detalla el comportamiento de la aplicación cuando el usuario presiona este botón.

[Proceso de Búsqueda]
Selección de Métodos y Parámetros:

El usuario selecciona el método de búsqueda preferido (Heap u otro método alternativo) desde la sección "Método".
Utilizando la barra deslizante etiquetada como "Resultados", el usuario determina la cantidad de resultados que desea obtener. En el ejemplo, la cantidad está ajustada a 3.
Acción del Botón "Buscar":

Al presionar el botón "Buscar", la aplicación toma los datos establecidos por el usuario (método de búsqueda y cantidad de resultados) y procede a ejecutar el algoritmo de búsqueda seleccionado.
Ejecución del Algoritmo:

Si se selecciona "Heap":
La aplicación invoca el método BuscarConHeap(datos, cantidad, collected) de la clase Estrategia. Este método procesa la lista de datos utilizando una Heap para encontrar los elementos con mayor número de ocurrencias.
Si se selecciona "Otro método":
La aplicación invoca el método BuscarConOtro(datos, cantidad, collected), implementado con una estrategia diferente a la Heap para realizar la misma tarea.
Procesamiento de Resultados:

El método seleccionado analiza los datos y llena la lista collected con los elementos más frecuentes, hasta el número especificado por el parámetro cantidad.
Visualización de Resultados:

La interfaz de usuario se actualiza para mostrar los resultados de la búsqueda. Los elementos con mayor número de ocurrencias se presentan en una lista, donde cada ítem incluye:
El nombre del elemento.
La cantidad de ocurrencias.
Un icono de verificación que indica que el elemento ha sido identificado correctamente.
En el ejemplo de la interfaz, se muestran tres elementos: "Mean-CD" con 5428 ocurrencias, "Mean-UHF42" con 3864 ocurrencias y "Mean-UHF34" con 3127 ocurrencias.

Interacción Adicional
Botón "Limpiar": Permite al usuario limpiar los resultados actuales y reiniciar el proceso de búsqueda.
Consultas Adicionales
Consulta 1: Muestra los tiempos de ejecución de los métodos BuscarConHeap y BuscarConOtro.
Consulta 2: Detalla el camino hacia la hoja más izquierda de la Heap.
Consulta 3: Proporciona una descripción de los datos de la Heap, indicando los niveles de los elementos.

[Diseño del Sistema]
En esta sección se presenta el diseño técnico del sistema, incluyendo el diagrama UML que ilustra las clases principales, sus métodos y las relaciones entre ellas. Este diagrama proporciona una visión clara de la estructura del aplicativo y facilita la comprensión de su funcionamiento interno.


[Diagrama UML: ]
El diagrama UML muestra la clase Backend, Estrategia, HeapSort y sus métodos, así como la clase Dato y cualquier otra clase relevante que interactúe con ellas. Este diagrama ayuda a visualizar cómo se organizan y colaboran los diferentes componentes del sistema.
A continuación, se describen los métodos que desarrollados:
Descripción de las Clases
Clase Backend:
Responsabilidades: Actúa como interfaz principal para realizar consultas y búsquedas en los datos.
Atributos:
list<string> datos: Lista estática que contiene los datos a procesar.
Métodos:
caminoAPrediccion(): Realiza la consulta 2 sobre los datos.
todasLasPredicciones(): Realiza la consulta 1 sobre los datos.
buscar(bool heapOP, int cantidad, List<Dato> collected): Realiza una búsqueda utilizando el método especificado (con heap o no).


[Clase Estrategia:]
Responsabilidades: Define varias consultas y métodos de búsqueda sobre los datos.
Métodos:
Consulta1(List<string> datos): Compara tiempos de ejecución de dos métodos de búsqueda y retorna los promedios.
Consulta2(List<string> datos): Genera y retorna el camino a la hoja más a la izquierda en un heap construido a partir de los datos.
Consulta3(List<string> datos): Genera y retorna un texto con los niveles de los datos en el heap.
BuscarConHeap(List<string> datos, int cantidad, List<Dato> collected): Realiza una búsqueda utilizando una estructura heap.
BuscarConOtro(List<string> datos, int cantidad, List<Dato> collected): Realiza una búsqueda sin utilizar heap.
MaxCountDate(List<string> datos): Genera un diccionario con el recuento de ocurrencias de cada dato.


[Clase HeapSort:]
Responsabilidades: Ordenar un diccionario utilizando la estructura de datos heap.
Métodos:
Sort(Dictionary<string, int> conteo): Ordena el diccionario dado.
Heapify(List<KeyValuePair<string, int>> arr, int n, int i): 
Se encarga de realizar el filtrado para generar la heap.


[Clase Dato:]
Responsabilidades: Modelar un dato con su cantidad y texto asociado.
Atributos:
cantidad: Cantidad de ocurrencias del dato.
texto: Texto del dato.

[Propuestas de Futuras Mejoras]
Para mejorar el programa descrito en el documento, hay varias áreas en las que se pueden introducir mejoras y proponer futuras direcciones para el desarrollo. A continuación se presentan algunas sugerencias:
Optimización del Rendimiento:
Almacenamiento en Caché: Implementar almacenamiento en caché para resultados de búsquedas repetitivas o similares, lo que puede reducir el tiempo de respuesta en consultas frecuentes.
Mejoras en la Interfaz de Usuario:
Filtros Avanzados: Añadir opciones de filtrado más avanzadas para que los usuarios puedan refinar sus búsquedas basadas en diferentes criterios (por ejemplo, rango de fechas, categorías específicas).
Exportación de Resultados: Permitir la exportación de los resultados de búsqueda en diferentes formatos (CSV, JSON, etc.) para facilitar el análisis externo y la integración con otras herramientas.
Mayor Robustez y Manejo de Errores:
Validación de Datos: Implementar una validación exhaustiva de los archivos CSV antes de procesarlos para manejar mejor los errores y los datos corruptos.
Manejo de Excepciones: Mejorar el manejo de excepciones y proporcionar mensajes de error más descriptivos para una mejor experiencia del usuario y facilidad de depuración.

[Problemas encontrados]
Al comienzo del desarrollo del sistema me encontré con dos problemas/dificultades para hacer correr el proyecto. Estos son:
Error de archivos bloqueados:
  Link para solucionarlo: 
    https://learn.microsoft.com/es-es/powershell/module/microsoft.powershell.utility/unblock-file?view=powershell-7.4
  Para solucionarlo tuve que ir a cada archivo ".resx" y en las propiedades aplicar la opcion de "Unblock" para desbloquearlos
  Otra opción es ejecutar el comando: Unblock-File -Path "Form1.resx" por cada archivo que se encuentre con ese problema

No existe archivo “.csv” en la ruta propuesta por la cátedra:
En la primer versión descargada del programa el archivo “.csv” que debería estar en la ruta “..\clutil\TPFinal\\datasets\dataset.csv” no existía por lo que para empezar a programar el proyecto tuve que crear uno a mano en base a los criterios propuestos por el sistema para que funcione.

[Conclusión]
Este informe detalla el proceso y las técnicas empleadas para completar el buscador de máximas ocurrencias, destacando las funcionalidades implementadas y su importancia en la eficiencia del aplicativo. La combinación de diferentes métodos de búsqueda y la capacidad de evaluar su rendimiento proporciona a la empresa una herramienta robusta y versátil para el análisis de datos.

El sistema está bien estructurado, con una clara separación de responsabilidades entre las clases. Backend actúa como el punto de acceso principal, delegando las operaciones de búsqueda y consulta a Estrategia, que a su vez utiliza HeapSort para operaciones de ordenación específicas. Los métodos están diseñados para manejar eficientemente los datos y proporcionar información detallada sobre los procesos de búsqueda y ordenación.

