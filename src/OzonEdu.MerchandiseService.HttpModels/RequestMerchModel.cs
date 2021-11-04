using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class RequestMerchModel
    {
        public int SenderId { get; set; }

        public int RecieverId { get; set; }

        public int PackId { get; set; }

        public int Quantity { get; set; }
    }
}
