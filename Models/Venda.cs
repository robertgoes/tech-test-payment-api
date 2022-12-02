namespace tech_test_payment_api.Models
{
    public class Venda
    {
        public int VendaId { get; set; }

        public string Status { get; set; }

        public string Item { get; set; }

        public DateTime Data { get; set; }

        public string Cpf { get; set; }
        
        public string Nome { get; set; }
        
        public string Email { get; set; }
        
        public string Telefone { get; set; }
        public int PedidoId { get; set; }

        public string AtualizarStatus(string status)
        {
            string _status = this.Status;

            switch (_status)
            {
                case "Aguardando Pagamento":
                    if(status == "Pagamento Aprovado" || status == "Cancelada")
                    {
                        _status = status;
                    }
                    break;
                case "Pagamento Aprovado":
                    if (status == "Enviado para Transportadora" || status == "Cancelada")
                    {
                        _status =  status;
                    }
                    break;
                case "Enviado Para Transportadora":
                    if (status == "Entregue")
                    {
                        _status = status;
                    }
                    break;
                default:
                    break;
            }

            return _status;
        }
    }
}