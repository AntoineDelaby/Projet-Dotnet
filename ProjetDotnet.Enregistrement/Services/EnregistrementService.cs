using AutoMapper;

namespace ProjetDotnet.Server.API.Services
{
    public class EnregistrementService
    {
        private readonly EnregistrementRepository _repo;
        private readonly IMapper _mapper;

        public EnregistrementService(IMapper mapper)
        {
            _repo = new EnregistrementRepository();
            _mapper = mapper;
        }
        public bool IsValidCardNumber(string cardNumber)
        {
            // Verification que cardNumber n'est pas null
            if (string.IsNullOrWhiteSpace(cardNumber))
                return false;

            // Verification que cardNumber n'a que des chiffres
            cardNumber = cardNumber.Replace(" ", "");
            if (!cardNumber.All(char.IsDigit))
                return false;

            // Calcul luhn
            int sum = 0;
            // Permet de definir si c'est pair ou non, si c'est impair, ca veut dire qu'on mutliplie par 2
            bool alternate = false;
            int digit = 0;
            for(int i = cardNumber.Length-1;i >= 0; i--)
            {
                digit = cardNumber[i] - '0';

                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
                // on passe de pair/impair à impair/pair
                alternate = !alternate;
            }

            // Si la somme est un multiple de 10 alors c'est bon
            return (sum % 10 == 0);
        }
    }
}
