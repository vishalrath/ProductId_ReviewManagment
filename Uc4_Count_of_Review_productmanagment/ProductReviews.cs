﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uc4_Count_of_Review_productmanagment
{
    class ProductReviews
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public float Rating { get; set; }
        public string Review { get; set; }
        public bool IsLike { get; set; }
    }
}
