using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace church_mgt_model.ViewModels
{
    public class OnlineGivingViewModel
    {
        public string FullName { get; set; }
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public string PaymentType { get; set; }
    }
}
