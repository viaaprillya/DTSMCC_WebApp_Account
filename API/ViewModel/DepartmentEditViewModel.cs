using Microsoft.AspNetCore.SignalR;

namespace API.ViewModel
{
    public class DepartmentEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }
    }
}
