namespace Rent_Car_Api.Managers
{
    public class ManagerResult<T>
    //public class ManagerResult
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public IList<T> Data { get; set; } 
        
    }
}
