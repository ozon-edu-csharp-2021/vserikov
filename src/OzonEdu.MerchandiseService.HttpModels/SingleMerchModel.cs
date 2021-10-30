using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class SingleMerchModel
    {
        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public string MerchType { get; set; }

        public int Quantity { get; set; }
    }
}
