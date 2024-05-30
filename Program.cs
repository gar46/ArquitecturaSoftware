using Microsoft.Extensions.DependencyInjection;
using MediatR;
using TorreDeControl.Modelos;
using TorreDeControl.Comandos;
using TorreDeControl.Consultas;
using System.Reflection;
using System;

namespace TorreDeControl
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var servicios = new ServiceCollection();
            ConfigurarServicios(servicios);
            var proveedor = servicios.BuildServiceProvider();

            var mediador = proveedor.GetRequiredService<IMediator>();

         
            var random = new Random();
            var aviones = new List<Avion>();

           
            for (int i = 1; i <= 20; i++)
            {
                var id = $"Avion{i}";
                var estado = random.Next(2) == 0 ? "EnVuelo" : "Aterrizado"; 
                aviones.Add(new Avion { Id = id, Estado = estado });
            }

            Console.WriteLine("Aviones generados:");
            foreach (var avion in aviones.OrderBy(avion => avion.Id)) 
            {
                Console.WriteLine($"Avion ID: {avion.Id}, Estado: {avion.Estado}");
            }

           
            foreach (var avion in aviones.OrderBy(avion => avion.Id))
            {
                if (avion.Estado == "EnVuelo")
                {
                    await mediador.Send(new AterrizarAvionComando(avion.Id));
                    avion.Estado = "Aterrizado"; 
                }
                else 
                {
                    await mediador.Send(new DespegarAvionComando(avion.Id));
                    avion.Estado = "EnVuelo"; 
                }

                
                Console.WriteLine($"Avion ID: {avion.Id}, Estado: {avion.Estado}");
                Thread.Sleep(1000); 
            }



        }


        private static void ConfigurarServicios(IServiceCollection servicios)
        {
            servicios.AddMediatR(typeof(Program));
            servicios.AddSingleton<List<Avion>>();
            servicios.AddTransient<IRequestHandler<AterrizarAvionComando, Unit>, AterrizarAvionComandoManejador>();
            servicios.AddTransient<IRequestHandler<DespegarAvionComando, Unit>, DespegarAvionComandoManejador>();
            servicios.AddTransient<IRequestHandler<ObtenerAvionesConsulta, List<Avion>>, ObtenerAvionesConsultaManejador>();
        }
    }
}
