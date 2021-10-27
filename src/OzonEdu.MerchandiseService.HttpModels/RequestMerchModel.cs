using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class RequestMerchModel
    {
        public int RecieverId { get; set; }
        public string MerchType { get; set; }
        public int Quantity { get; set; }
    }
}
