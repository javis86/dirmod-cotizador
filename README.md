# dirmod-cotizador

Aplicación completa de cotización desarrollada en Netcore + Vuejs para el examen técnico intentando dar un acercamiento al trabajo en DDD.



<img width="300px" src="https://miro.medium.com/max/1358/1*FRhVQKjgxBe8go8a559PcQ.png" alt="vip" />



#### Contenido del proyecto

El proyecto consta de dos proyectos principales uno realizado en .netcore y el otro realizado en Vuejs.



#### Frameworks y librerías

Ambos proyectos constan de su dockerfile y en el root de la solución están las configuraciones propias para  realizar el build y up  con docker-compose.

- [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [AutoMapper](https://automapper.org/) (para el mapeo de objetos)

- [VUE.JS](https://vuejs.org/) (The progressive  Javascript Framework)
- [Docker](https://www.docker.com/) (Securely build and share any application, anywhere)
- [Docker Compose](https://docs.docker.com/compose/)



#### Demos

Aplicación front: [VUEJS WEB APP](http://34.95.207.136/)

Aplicación back: [NETCORE API cotizacion/dolar](http://35.199.108.169/cotizacion/dolar)



#### Ejecutar Aplicación web Vuejs

Ingresar al directorio Dirmod.Cotizador.Webapp y ejecutar los siguientes pasos:

1- Instalación de entorno

```
npm install
```

2- Ejecución de entorno de test

```
npm run serve
```



#### Ejecutar API netcore

Primero hay que instalar [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1), luego ingresar a la raíz del proyecto y ejecutar las siguientes instrucciones:

``` bash
dotnet restore
dotnet run
```







