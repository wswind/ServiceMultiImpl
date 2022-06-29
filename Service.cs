namespace ServiceMultiImpl
{
    public interface IService
    {
        string DoSth();
    }
    public class Service1 : IService
    {
        public string DoSth()
        {
            return "hello 1";
        }
    }

    public class Service2 : IService
    {
        public string DoSth()
        {
            return "hello 2";
        }
    }

}