using System;

namespace WebStoreGB.ViewModels
{
    public class AjaxTestDataViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Servertime { get; set; } = DateTime.Now;
    }
}
