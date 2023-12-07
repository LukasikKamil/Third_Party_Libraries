using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALLinONE.Entities;

public record class Cart(
    Customer Customer,
    List<LineItem> Items
);