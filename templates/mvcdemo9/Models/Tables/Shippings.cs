﻿using System;
using System.Collections.Generic;

namespace mvcdemo9.Models;

public partial class Shippings
{
    public int Id { get; set; }

    public string? ShippingNo { get; set; }

    public string? ShippingName { get; set; }

    public string? Remark { get; set; }
}
