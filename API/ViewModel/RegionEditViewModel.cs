using Microsoft.AspNetCore.SignalR;

namespace API.ViewModel
{
    public class RegionEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }
    }
}
