using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace arriendos
{


    public class Usuario
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public Usuario(string nombre, string direccion)
        {
            Nombre = nombre;
            Direccion = direccion;
        }
    }

    public class Monto_Contrato
    {
        public decimal MontoMensual { get; set; }
        public int idContrato { get; set; }

        public Monto_Contrato(decimal montoMensual, int idContrato)
        {
            MontoMensual = montoMensual;
            this.idContrato = idContrato;
        }
    }

    public class PagosArriendo : Monto_Contrato
    {
        public DateTime FechaPago { get; set; }

        public PagosArriendo(decimal montoMensual, int referenciaContrato, DateTime fechaPago)
            : base(montoMensual, referenciaContrato)
        {
            FechaPago = fechaPago;
        }

        public void GenerarFactura()
        {
            Console.WriteLine("------------Factura--------------");
            Console.WriteLine($"Fecha de pago: {FechaPago}");
            Console.WriteLine($"Monto pagado: {MontoMensual}");
        }
    }

    public class Arrendatario : Usuario
    {
        public List<ContratosArrendamiento> Contratos { get; } = new List<ContratosArrendamiento>();

        public Arrendatario(string nombre, string direccion) : base(nombre, direccion)
        {
        }

        public void AgregarContrato(ContratosArrendamiento contrato)
        {
            Contratos.Add(contrato);
        }

        public void RegistrarPagoMensual(ContratosArrendamiento contrato, decimal monto, DateTime fechaPago)
        {  
                var pago = new PagosArriendo(monto, contrato.idContrato, fechaPago);
                contrato.RegistrarPago(pago);
        }

        public static void AgregarArrendatario(List<Arrendatario> listaArrendatarios, Arrendatario arrendatario)
        {
            listaArrendatarios.Add(arrendatario);
        }
    }

    public class Arrendador : Usuario
    {
        public List<string> Propiedades { get; } = new List<string>();

        public Arrendador(string nombre, string direccion) : base(nombre, direccion)
        {
        }

        public void AgregarPropiedad(string propiedad)
        {
            Propiedades.Add(propiedad);
        }

        public static void AgregarArrendador(List<Arrendador> listaArrendadores, Arrendador arrendador)
        {
            listaArrendadores.Add(arrendador);
        }
    }

    public class ContratosArrendamiento : Monto_Contrato
    {
        public string PropiedadAlquilada { get; set; }
        public DateTime FechaInicio { get; set; }
        public List<PagosArriendo> Pagos { get; } = new List<PagosArriendo>();

        public ContratosArrendamiento(decimal montoMensual, int idContrato, string propiedadAlquilada, DateTime fechaInicio)
            : base(montoMensual, idContrato)
        {
            PropiedadAlquilada = propiedadAlquilada;
            FechaInicio = fechaInicio;
        }

        public void GenerarContrato()
        {
            Console.WriteLine("Detalles del contrato:");
            Console.WriteLine($"Propiedad alquilada: {PropiedadAlquilada}");
            Console.WriteLine($"Monto mensual: {MontoMensual}");
            Console.WriteLine($"Fecha de inicio: {FechaInicio}");
            Console.WriteLine($"Referencia de contrato: {idContrato}");
        }

        public void RegistrarPago(PagosArriendo pago)
        {
                Pagos.Add(pago);
        }

        public List<PagosArriendo> ObtenerPagos()
        {
            return Pagos;
        }
    }
}