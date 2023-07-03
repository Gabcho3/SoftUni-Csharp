const products = {
    coffee: (quantity) => 1.50 * quantity,
    water: (quantity) => 1.00 * quantity,
    coke: (quantity) => 1.40 * quantity,
    snacks: (quantity) => 2.00 * quantity
}
function calculatePrice(product, quantity){
    return products[product](quantity).toFixed(2);
}
console.log(calculatePrice('water', 5)); //5.00