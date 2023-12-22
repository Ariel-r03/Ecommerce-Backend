namespace EcommerceAPI.Dtos
{
    public class UserLoggedDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string ResultMessage { get; set; }
        public List<string> Roles { get; set; }
        
    }
}
