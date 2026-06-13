//ContaBancaria.cs
namespace relatorio4
{
    public class ContaBancaria
    {
        private decimal _saldo;
        public decimal Saldo { get => _saldo; }

        public ContaBancaria(decimal saldoInicial = 0m)
        {
            _saldo = saldoInicial;
        }

        public bool Depositar(decimal quantia)
        {
            if (quantia <= 0)
            {
                return false;
            }
            _saldo = quantia;
            return true;
        }

        public bool Sacar(decimal quantia)
        {
            if (quantia <= 0)
            {
                return false;
            }
            if (quantia > _saldo)
            {
                return false;
            }
            _saldo -= quantia;
            return true;
        }

    }
}

