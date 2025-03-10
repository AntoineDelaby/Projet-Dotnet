using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotnet.Client.App
{
    public enum ClientsExceptionType
    {
        InvalidName,
        InvalidMail,
        InvalidPrénom,
        InvalidSex,
        InvalidSiret
    }

    public class ClientsException : Exception
    {
        public ClientsExceptionType Type { get; set; }

        public ClientsException(ClientsExceptionType type)
             : base(GetMessage(type))
        {
            this.Type = type;
        }

        private static string? GetMessage(ClientsExceptionType type)
        {
            throw new NotImplementedException();
        }

        public string Message
        {
            get
            {
                string message = "Erreur - ";
                switch (Type)
                {
                    case ClientsExceptionType.InvalidName:
                        message += "Le nom ne doit pas dépasser 50 caractères.";
                        break;
                    case ClientsExceptionType.InvalidMail:
                        message += "Email invalide. Format attendu : doit contenir un @ exemple@test.fr";
                        break;
                    case ClientsExceptionType.InvalidPrénom:
                        message += "Le nom ne doit pas dépasser 50 caractères.";
                        break;
                    case ClientsExceptionType.InvalidSiret:
                        message += " Siret doit avoir 14 chiffres.";
                        break;
                    default:
                        message += "Erreur inconnue.";
                        break;
                }
                return message;



            }
        }
    }
}



