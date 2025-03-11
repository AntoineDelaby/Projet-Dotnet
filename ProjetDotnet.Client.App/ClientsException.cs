using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotnet.Client.App
{
    public enum ClientsExceptionType
    {
        InvalidNom,
        InvalidMail,
        InvalidPrenom,
        InvalidSex,
        InvalidSiret,
        InvalidAdresse
    }

    public class ClientsException : Exception
    {
        public ClientsExceptionType Type { get; set; }

        public ClientsException(ClientsExceptionType type)
             : base()
        {
            this.Type = type;
        }

        

        public override string Message
        {
            get
            {
                string message = "Erreur - ";
                switch (Type)
                {
                    case ClientsExceptionType.InvalidNom:
                        message += "Le nom ne doit pas dépasser 50 caractères.";
                        break;
                    case ClientsExceptionType.InvalidMail:
                        message += "Email invalide. Format attendu : doit contenir un @ exemple@test.fr";
                        break;
                    case ClientsExceptionType.InvalidPrenom:
                        message += "Le nom ne doit pas dépasser 50 caractères.";
                        break;
                    case ClientsExceptionType.InvalidSiret:
                        message += " Siret doit avoir 14 chiffres.";
                        break;
                    case ClientsExceptionType.InvalidAdresse:
                        message += "L'adresse postale n'est pas valide.";
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



