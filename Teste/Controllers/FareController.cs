using System;
using System.Linq;
using TestePleno.Models;
using TestePleno.Services;

namespace TestePleno.Controllers
{
    public class FareController
    {
        private OperatorService _operatorService;
        private FareService FareService;

        public FareController()
        {
            _operatorService = new OperatorService();
            FareService = new FareService();
        }

        public void CreateFare(Fare fare, string operatorCode)
        {
            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            
            if (selectedOperator == null)
            {
                selectedOperator = new Operator { Id = Guid.NewGuid(), Code = operatorCode };
                _operatorService.Create(selectedOperator);

                if (FareService.TimeValidator(selectedOperator.Id))
                {
                    fare.OperatorId = selectedOperator.Id;
                    fare.Status = 1;
                    fare.DateStamp = DateTimeOffset.UtcNow;
                    FareService.Create(fare);
                }
            }
           
            else
            {
                throw new Exception($"\n\nErro: Já possui uma tarifa ativa para operadora {operatorCode} e não é possível cadastrar novamente.\n");
            }
        }
    }
}
