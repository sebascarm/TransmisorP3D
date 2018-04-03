**Transmisor P3D**
==========

Software encargado de la intercomunicacion entre Arduino y P3D PMDG mediante dos canales de comunicación.

Caracteristicas principales
---------------------------

 - Gestión de la comunicación con Arduino.
 - Gestión de comunicación con P3D mediante SimConnect.
 - Gestión de transmision de datos a procesos remotos mediante Socket.
 - Gestión remota.
 
  
Comunicación
------------

En resumen este software se instala en un Equipo mediador, el cual se conectará fisicamente con 2 placas Arduino a travez de su puertos serie y el programa se encargara de analizar los paquetes y datos recibidos para traducirlos y transmitir en forma remota o local al Servidor P3D mediante SimConnect.

Transmisor de datos remotos
---------------------------
Comunicación conta software **Comandos** para ejecución de procesos y eventos en forma remota.

Gestión Remota
--------------
Aplicación Cliente Servidor para analizar y gestionar la transmisión de forma remota.

