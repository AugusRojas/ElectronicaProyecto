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
using DocumentFormat.OpenXml.Bibliography;
using LogicLayer.DTO;
using System.Security.Principal;

namespace LogicLayer.ValidatorService
{
    public class DocumentCashClosing : IDocument
    {
        public List<DTOProductsXSales> _productsXSales { get; set; } = new List<DTOProductsXSales>();
        public DocumentCashClosing(List<DTOProductsXSales> productsXSales)
        {
            _productsXSales = productsXSales;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.DefaultTextStyle(x => x.FontSize(12));
                double total = 0;
                page.Content().Column(col =>
                {
                    col.Item().Text("Resumen de ventas").Bold().FontSize(18);
                    col.Item().Text($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}");
                    col.Item().Text("");
                    col.Item().LineHorizontal(1);
                    col.Item().Text("");

                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(2); // Producto
                            columns.RelativeColumn(1); // Cantidad
                            columns.RelativeColumn(1); // Precio
                            columns.RelativeColumn(1); // Subtotal
                            columns.RelativeColumn(1); // Descuento
                            columns.RelativeColumn(2); // Fecha
                            columns.RelativeColumn(2); // Hora
                        });

                        // Cabecera
                        table.Header(header =>
                        {
                            header.Cell().Element(StyleHeader).Text("Producto");
                            header.Cell().Element(StyleHeader).AlignCenter().Text("Cant.");
                            header.Cell().Element(StyleHeader).AlignCenter().Text("Precio");
                            header.Cell().Element(StyleHeader).AlignCenter().Text("Subtotal");
                            header.Cell().Element(StyleHeader).AlignCenter().Text("Desc.");
                            header.Cell().Element(StyleHeader).AlignCenter().Text("Fecha");
                            header.Cell().Element(StyleHeader).AlignCenter().Text("Hora");

                            static IContainer StyleHeader(IContainer container)
                            {
                                return container
                                    .Background(Colors.Grey.Lighten3)
                                    .PaddingVertical(6).PaddingHorizontal(4)
                                    .DefaultTextStyle(x => x.SemiBold())
                                    .BorderBottom(1).BorderColor(Colors.Grey.Darken2);
                            }
                        });

                        // Filas
                     
                    foreach (var item in _productsXSales)
                    {
                        table.Cell().Element(StyleCell).Text(item.name);
                        table.Cell().Element(StyleCell).AlignCenter().Text($"{item.amount}");
                        table.Cell().Element(StyleCell).AlignCenter().Text($"${item.totalAmount:F2}");
                        table.Cell().Element(StyleCell).AlignCenter().Text($"${item.subtotal:F2}");
                        table.Cell().Element(StyleCell).AlignCenter().Text($"{item.discount:F2}%");
                        table.Cell().Element(StyleCell).AlignCenter().Text($"{item.date:dd/MM/yyyy}");
                        table.Cell().Element(StyleCell).AlignCenter().Text($"{item.hour:HH:mm:ss}");

                            static IContainer StyleCell(IContainer container)
                            {
                                return container
                                    .PaddingVertical(4).PaddingHorizontal(4)
                                    .BorderBottom(0.5f)
                                    .BorderColor(Colors.Grey.Lighten2);
                            }
                        total += Convert.ToDouble(item.subtotal);
                        }
                    });

                    col.Item().Text("");
                    col.Item().AlignRight().Text($"Total General: ${total:F2}").FontSize(14).Bold();
                });
            });
        }

    }
}
