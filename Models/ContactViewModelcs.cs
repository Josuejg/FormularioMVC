using System.Collections.Generic;

namespace FormularioMVC.Models
{
    public class ContactViewModel
    {
        public ContactMessage NuevoMensaje { get; set; }
        public List<ContactMessage> Mensajes { get; set; }
    }
}
