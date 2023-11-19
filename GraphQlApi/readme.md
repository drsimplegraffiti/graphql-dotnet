SOURCE: https://medium.com/@jaydeepvpatil225/graphql-introduction-and-product-application-using-net-core-bd37faf3c585


##### Serve the app
http://localhost:5217/graphql/

##### Query
productList
```graphql
query {
  productList {
    id
    productName
    productStock
    productDescription
    productPrice
  }
}
```



##### Mutation
deleteProduct
```graphql
mutation($productId:UUID!){
  deleteProduct(productId: $productId)
}
```
```json
{
  "productId": "1"
}
```


##### Add Product
addProduct
```graphql
mutation($productDetails:ProductDetailsInput!){
  addProduct(productDetails: $productDetails)
}
```
```json
{
    "productDetails": {
        "id": "939d05f4-86ae-11ee-b9d1-0242ac120002",
        "productName": "Product 1",
        "productStock": 10,
        "productDescription": "Product 1 Description",
        "productPrice": 10.0
    }
    }
```

##### Update Product
updateProduct
```graphql
mutation($productDetails:ProductDetailsInput!){
  updateProduct(productDetails: $productDetails)
}
```
```json
{
    "productDetails": {
        "id": "939d05f4-86ae-11ee-b9d1-0242ac120002",
        "productName": "Product 1",
        "productStock": 10,
        "productDescription": "Product 1 Description",
        "productPrice": 10.0
    }
    }
```

##### GET Single Product
product
```graphql
query($productId:UUID!){
  productDetailsById(productId: $productId){
    id
    productName
    productStock
    productDescription
    productPrice
  }
}
```

```json
{
    "productId": "939d05f4-86ae-11ee-b9d1-0242ac120002"
}
```
