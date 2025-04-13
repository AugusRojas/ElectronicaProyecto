BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Category" (
	"idCategory"	INTEGER NOT NULL,
	"name"	INTEGER,
	PRIMARY KEY("idCategory" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "PaymentMethod" (
	"idPaymentMethod"	INTEGER NOT NULL,
	"namePaymentMethod"	TEXT NOT NULL,
	PRIMARY KEY("idPaymentMethod" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Product" (
	"idProduct"	INTEGER NOT NULL,
	"name"	TEXT NOT NULL,
	"stock"	INTEGER NOT NULL,
	"price"	REAL NOT NULL,
	"idCategory"	INTEGER,
	PRIMARY KEY("idProduct" AUTOINCREMENT),
	CONSTRAINT "FK_Category" FOREIGN KEY("idCategory") REFERENCES "Category"("idCategory")
);
CREATE TABLE IF NOT EXISTS "ProductsXSales" (
	"idPxs" INTEGER NOT NULL PRIMARY KEY  AUTOINCREMENT,
	"idProduct"	INTEGER NOT NULL,
	"idSale"	INTEGER NOT NULL,
	"amount"	INTEGER NOT NULL,
	"subtotal"	REAL NOT NULL,
	"discount"	INTEGER NOT NULL,
	CONSTRAINT "Fk_Product" FOREIGN KEY("idProduct") REFERENCES "Product"("idProduct"),
	CONSTRAINT "Fk_Sale" FOREIGN KEY("idSale") REFERENCES "Sale"("idSale")
);
CREATE TABLE IF NOT EXISTS "Sale" (
	"idSale"	INTEGER NOT NULL,
	"idPaymentMethod"	INTEGER NOT NULL,
	"totalAmount"	INTEGER NOT NULL,
	"hour"	TEXT NOT NULL,
	"date"	TEXT NOT NULL,
	"discount"	INTEGER,
	"subtotal"	REAL,
	PRIMARY KEY("idSale"),
	CONSTRAINT "Fk_PaymentMethod" FOREIGN KEY("idPaymentMethod") REFERENCES "PaymentMethod"("idPaymentMethod")
);

CREATE INDEX IF NOT EXISTS "idx_product_name" ON "Product" (
	"name"
);
COMMIT;
