using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace church_mgt_model.ViewModels
{
    public class OnlineGivingResponseViewModel
    {
        public string Authorization_Url { get; set; }
        public string Access_Code { get; set; }
        public string Reference { get; set; }
    }
}
