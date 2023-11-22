import './Product.css';
function Product()
{
    var product={
        name :"Pencil",
        price:12.5,
        quantity:5
    }
    var CheckQuantity=product.quantity>0?true:false;
        return(
            <div className='product'>
                {CheckQuantity?
                    <div>
                    Product Name : {product.name}
                    <br/>
                    Product Price:{product.price}
                    <br/>
                    Product Quantity:{product.quantity}
                    </div>
                :
                <div>Product out of Stock</div>}
            </div>
                
        );
}
export default Product;