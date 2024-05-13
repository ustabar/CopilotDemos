  public ProductDetails GetProductInfo(string productName)
  {
      ProductDetails product = new ProductDetails();
      ShippingInfo shipping = new ShippingInfo();
      product.ProductName = productName;
      shipping.Distributor = "Buggy Bits";
      shipping.DaysToShip = 5;
      product.ShippingInfo = shipping;

      Type[] extraTypes = new Type[1];
      extraTypes[0] = typeof(ShippingInfo);

      MemoryStream stream = new MemoryStream();
      XmlSerializer serializer = new XmlSerializer(typeof(ProductDetails), extraTypes);
      serializer.Serialize(stream, product);

      // TODO: save off the data to an xml file or pass it as a string somewhere

      stream.Close();

      return product;
  }