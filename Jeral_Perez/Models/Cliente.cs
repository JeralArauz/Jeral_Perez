namespace Jeral_Perez.Models
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set;}
        public string Telefono { get; set;}
        public int Edad { get; set;}
    }
    public class ClientePrestamo
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Monto { get; set; }
        public string Saldo { get; set; }
    }
}
