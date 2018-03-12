namespace TddTotalAmount
{
    public class Accounting
    {
        private IRespository<Budget> _respository;

        public Accounting(IRespository<Budget> respository)
        {
            _respository = respository;
        }
    }
}