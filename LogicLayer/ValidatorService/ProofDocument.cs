using DataLayer.Models;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Drawing;
using QuestPDF.Elements;

namespace LogicLayer.ValidatorService
{
    public class ProofDocument : IDocument
    {
        //clase para determinar la estructura del comprobante
        private  Sale sale;
        public ProofDocument(Sale sale)
        {
            this.sale = sale;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.DefaultTextStyle(x => x.FontSize(12));

                page.Content().Column(col =>
                {
                    col.Item().Text($"Comprobante de Venta N° {sale.idSale}").Bold().FontSize(18);
                    col.Item().Text($"Fecha: {sale.date:dd/MM/yyyy}");
                    col.Item().Text($"Hora: {sale.hour}");
                    col.Item().Text($"Método de pago: {sale.PaymentMethod.namePaymentMethod}");
                    col.Item().Text(""); 
                    col.Item().Text("");
                    col.Item().Text("");
                    col.Item().LineHorizontal(1);

                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(3); // Producto
                            columns.RelativeColumn(1); // Cantidad
                            columns.RelativeColumn(1); // Precio
                            columns.RelativeColumn(1); // Descuento
                            columns.RelativeColumn(1); // Subtotal
                        });

                        // Cabecera de la tabla
                        table.Header(header =>
                        {
                            header.Cell().Element(StyleHeader).Text("Producto");
                            header.Cell().Element(StyleHeader).AlignCenter().Text("Cant.");
                            header.Cell().Element(StyleHeader).AlignCenter().Text("Precio");
                            header.Cell().Element(StyleHeader).AlignCenter().Text("Desc.");
                            header.Cell().Element(StyleHeader).AlignRight().Text("Subtotal");

                            static IContainer StyleHeader(IContainer container)
                            {
                                return container
                                    .Background(Colors.Grey.Lighten3)
                                    .PaddingVertical(6).PaddingHorizontal(4)
                                    .DefaultTextStyle(x => x.SemiBold())
                                    .BorderBottom(1).BorderColor(Colors.Grey.Darken2);
                            }
                        });

                        //filas
                        foreach (var item in sale.ProductsXSales)
                        {
                            table.Cell().Element(StyleCell).Text(item.product.name);
                            table.Cell().Element(StyleCell).AlignCenter().Text(item.amount.ToString());
                            table.Cell().Element(StyleCell).AlignCenter().Text($"${item.product.price:F2}");
                            table.Cell().Element(StyleCell).AlignCenter().Text($"{item.discount}%");
                            table.Cell().Element(StyleCell).AlignRight().Text($"${item.subtotal:F2}");
                        }
                        //metodo para determinar estilos por defectos 
                        static IContainer StyleCell(IContainer container)
                        {
                            return container
                                .PaddingVertical(4).PaddingHorizontal(4)
                                .BorderBottom(0.5f)
                                .BorderColor(Colors.Grey.Lighten2);
                        }
                    });

                    col.Item().Text("");
                    col.Item().Text("");
                    col.Item().AlignRight().Text($"Total: ${sale.totalAmount:F2}").FontSize(14).Bold();
                });
            });
        }
    }

}
